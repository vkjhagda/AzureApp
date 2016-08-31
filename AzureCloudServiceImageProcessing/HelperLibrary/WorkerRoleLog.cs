using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace HelperLibrary
{
    public class WorkerRoleLog : TableEntity
    {        
        public string ActionTarget { get; set; }
        public string ActionMessage { get; set; }

        public static void CreateTable(string tableName)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(tableName);
            table.CreateIfNotExists();         
        }
        public static void InsertEntity(string tableName, string actionType,string actionTarget, string actionMessage)
        {
            WorkerRoleLog workerRoleLog = new WorkerRoleLog(); 
            workerRoleLog.PartitionKey = actionType;
            workerRoleLog.RowKey = DateTime.Now.ToString("ddmmyyyy")+actionTarget;
            workerRoleLog.ActionTarget = actionTarget;
            workerRoleLog.ActionMessage = actionMessage;           

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
          CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(tableName);
            
            TableOperation insertOperation = TableOperation.Insert(workerRoleLog);
            table.Execute(insertOperation);
        }
    }
}

