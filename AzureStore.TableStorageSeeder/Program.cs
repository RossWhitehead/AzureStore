using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Table;
using AzureStore.Data.TableStorage;

namespace AzureStore.TableStorageSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount account = 
                CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["TableStorage"].ConnectionString);
            CloudTableClient tableClient = account.CreateCloudTableClient();

            CloudTable orderTable = tableClient.GetTableReference("OrderTable");
            orderTable.CreateIfNotExists();

            Order order = new Order();
            order.PartitionKey = "000000001";
            order.RowKey = "000000001:000000001:Order";
            order.OrderDate = DateTime.Now;
            order.CustomerFullName = "Ross Whitehead";
            
            OrderLine orderLine1 = new OrderLine();
            orderLine1.PartitionKey = "000000001";
            orderLine1.RowKey = "000000001:000000001:OrderLine";
            orderLine1.ProductName = "Wheels";
            orderLine1.Quantity = 1;
            orderLine1.Price = 259.00M;

            OrderLine orderLine2 = new OrderLine();
            orderLine2.PartitionKey = "000000001";
            orderLine2.RowKey = "000000001:000000002:OrderLine";
            orderLine2.ProductName = "Gloves";
            orderLine2.Quantity = 1;
            orderLine2.Price = 29.99M;

            TableBatchOperation batchOperation = new TableBatchOperation();
            batchOperation.Insert(order);
            batchOperation.Insert(orderLine1);
            batchOperation.Insert(orderLine2);

            orderTable.ExecuteBatch(batchOperation);
        }
    }
}
