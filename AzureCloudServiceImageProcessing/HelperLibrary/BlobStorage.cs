using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;

namespace HelperLibrary
{
    public class BlobStorage
    {
        public static void CreateContainerIfNotExists(string containerName)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Create the container if it doesn't already exist.
            if (container.CreateIfNotExists())
            {
                container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
        }
        public static Uri UploadImageToContainer(string containerName,Image img, string imageName )
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(imageName);
            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);

            // Create or overwrite the "myblob" blob with contents from a local file.
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            blockBlob.UploadFromStream(ms);

            return blob.Uri;
        }

        public static string UploadImageToContainer(string containerName,HttpPostedFileBase postedFile)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(postedFile.FileName);
            // Retrieve reference to a blob named "myblob".

            string fileName = string.Concat(Guid.NewGuid(), postedFile.FileName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            // Create or overwrite the "myblob" blob with contents from a local file.

            blockBlob.UploadFromStream(postedFile.InputStream);
            var url = blockBlob.StorageUri.PrimaryUri;
            // Retrieve reference to a blob named "myblob". 
            return url.ToString();
        }

        
        public static void RetrieveAllImages(string containerName,out List<Uri> imageUrl)
        {
            //Display all images
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
               CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            if (container.CreateIfNotExists())
            {
                container.SetPermissions(
                 new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            // Retrieve a reference to a container.
            List<Uri> blobList = new List<Uri>();
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                blobList.Add(item.Uri);
            }
            imageUrl = blobList;
        }
    }
}
