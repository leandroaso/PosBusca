using BuscaRua.Models;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace BuscaRua.Base
{
    public class BaseDao
    {
        public readonly CloudTable EntityCloudTable;

        public BaseDao(string TableName)
        {

            var connString = CloudConfigurationManager.GetSetting("DataConnectionString");

            var storageAccount = CloudStorageAccount.Parse(connString);
            var tableClient = storageAccount.CreateCloudTableClient();
            tableClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(1), 3);

            EntityCloudTable = tableClient.GetTableReference(TableName);
            EntityCloudTable.CreateIfNotExists();
        }
    }
}