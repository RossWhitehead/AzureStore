using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStore.Data.TableStorage
{
    public class Order : OrderEntity
    {
        public DateTime OrderDate { get; set; }

        public string OrderReference { get; }

        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }

        public List<OrderLine> OrderLineItems { get; set; }

        protected override OrderEntityType OrderEntityType
        {
            get
            {
                return OrderEntityType.Order;
            }
        }
    }
}
