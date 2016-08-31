using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace HelperLibrary
{
    public class SignInLog : TableEntity
    {

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
        public static void InsertEntity(string tableName, string email)
        {
            SignInLog signInLog = new SignInLog();
            signInLog.PartitionKey = email;
            signInLog.RowKey = DateTime.Now.ToString("ddmmyyyy");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
         CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(tableName);

            TableOperation insertOperation = TableOperation.Insert(signInLog);
            table.Execute(insertOperation);

        }
    }

}
