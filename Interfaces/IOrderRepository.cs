using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Interfaces
{
    public interface IOrderRepository
    {
         void CreateOrder(Order order);
    }
}