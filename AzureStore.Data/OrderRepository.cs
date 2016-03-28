using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureStore.Data.TableStorage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace AzureStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        CloudStorageAccount account;
        CloudTableClient tableClient;
        CloudTable orderTable;

        public OrderRepository()
        {
            account = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["TableStorage"].ConnectionString);
            tableClient = account.CreateCloudTableClient();
            orderTable = tableClient.GetTableReference("OrderTable");
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string orderReference)
        {
            // Order reference is used as the PartitionKey for the Order and OrderLine records
            TableQuery<Order> query = new TableQuery<Order>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, orderReference));

            List<OrderEntity> orderEntityList = new List<OrderEntity>();
            TableQuerySegment<OrderEntity> currentSegment = null;
            while (currentSegment == null || currentSegment.ContinuationToken != null)
            {
                currentSegment = orderTable.ExecuteQuerySegmented(query, orderResolver, currentSegment != null ? currentSegment.ContinuationToken : null);
                orderEntityList.AddRange(currentSegment.Results);
            }

            return null;
        }

        EntityResolver<OrderEntity> orderResolver = (pk, rk, ts, props, etag) =>
        {
            OrderEntity entity = null;
            OrderEntityType type = (OrderEntityType)props["OrderEntityType"].Int32Value;

            if (type == OrderEntityType.Order) { entity = new Order(); }
            else { entity = new OrderLine(); }

            entity.PartitionKey = pk;
            entity.RowKey = rk;
            entity.Timestamp = ts;
            entity.ETag = etag;
            entity.ReadEntity(props, null);

            return entity;
        };
    }
}
