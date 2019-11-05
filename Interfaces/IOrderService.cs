using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Interfaces
{
    public interface IOrderService
    {
         void CreateOrder(Order order);
    }
}