using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStore.Data.TableStorage
{
    public class OrderLine : OrderEntity
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        protected override OrderEntityType OrderEntityType
        {
            get
            {
                return OrderEntityType.OrderLine;
            }
        }
    }
}
