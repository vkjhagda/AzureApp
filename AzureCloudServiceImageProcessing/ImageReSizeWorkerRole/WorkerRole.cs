using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Drawing;
using HelperLibrary;
using Microsoft.Azure;
using System;

namespace ImageResizingWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            string workerRoleLogTableName = CloudConfigurationManager.GetSetting("WorkerRoleLogTableName").ToString();
            WorkerRoleLog.CreateTable(workerRoleLogTableName);
            string imageUri;
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                string imageResizeQueueName = CloudConfigurationManager.GetSetting("QueueName").ToString();
                imageUri = Queue.DeQueue(imageResizeQueueName);

                if (imageUri != null)
                {
                    WorkerRoleLog.InsertEntity(workerRoleLogTableName, "DeQueue", imageResizeQueueName, "Dequeued the request for processing element with URI : " + imageUri);
                    WebClient wc = new WebClient();
                    Image originalImage = Image.FromStream(wc.OpenRead(imageUri));
                    Image Image20by20 = ImageProcessor.ResizeImage(originalImage, new Size(20, 20));
                    Image Image40by40 = ImageProcessor.ResizeImage(originalImage, new Size(40, 40));

                    string images20by20ContainerName = CloudConfigurationManager.GetSetting("Images20by20").ToString();
                    string images40by40ContainerName = CloudConfigurationManager.GetSetting("Images40by40").ToString();

                    BlobStorage.CreateContainerIfNotExists(images20by20ContainerName);
                    BlobStorage.CreateContainerIfNotExists(images40by40ContainerName);

                    
                    string imageName = imageUri.Substring(imageUri.LastIndexOf('/') + 1);

                    BlobStorage.UploadImageToContainer(images20by20ContainerName, Image20by20, imageName);
                    WorkerRoleLog.InsertEntity(workerRoleLogTableName, "Upload to Container", images20by20ContainerName, "Uploaded 20X20 processed Image : " + imageName);
                    BlobStorage.UploadImageToContainer(images40by40ContainerName, Image40by40, imageName);
                    WorkerRoleLog.InsertEntity(workerRoleLogTableName, "Upload to Container", images40by40ContainerName, "Uploaded 40X40 processed Image : " + imageName);
                }
                else
                {
                    Debug.WriteLine("waiting for an image");
                }
                await Task.Delay(1000);
            }
        }
    }
}
