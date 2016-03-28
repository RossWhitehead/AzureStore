using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStore.Data.TableStorage
{
    public abstract class OrderEntity : TableEntity
    {
        protected abstract OrderEntityType OrderEntityType { get; }
    }
}