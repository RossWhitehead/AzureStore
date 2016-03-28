using AzureStore.Data.TableStorage;

namespace AzureStore.Data
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Order GetOrder(string orderReference);
    }
}
