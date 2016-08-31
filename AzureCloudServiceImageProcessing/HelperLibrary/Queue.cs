
using Microsoft.Azure; // Namespace for CloudConfigurationManager 
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount 
using Microsoft.WindowsAzure.Storage.Queue;

namespace HelperLibrary
{
    public class Queue
    {
        public static void CreateQueue(string queueName)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            
            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();
        }

        public static void InsertIntoQueue(string queueName,string Url)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

          
            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist.
            queue.CreateIfNotExists();

            // Create a message and add it to the queue.
            CloudQueueMessage blobURL = new CloudQueueMessage(Url);
            queue.AddMessage(blobURL);
        }

        public static string DeQueue(string queueName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            queue.FetchAttributes();
            if (queue.ApproximateMessageCount != 0)
            {
                // Get the next message
                CloudQueueMessage retrievedMessage = queue.GetMessage();
                //Process the message in less than 30 seconds, and then delete the message
                queue.DeleteMessage(retrievedMessage);
                return retrievedMessage.AsString;
            }
            else
            {
                return null;
            }
        }

    }
}
