using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IOrderService
    {
        Task ProcessOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int Id);
        Task UpdateOrderAsync(Order order);
        Task RemoveOrderAsync(int Id);
        Task RemoveOrderAsync(Order order);
        Task CancelOrderAsync(Order order);
        Task CancelOrderAsync(int orderId);
        Task<bool> ValidateOrderAsync(Order order);
        Task<bool> ValidateOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId, OrderStatus status);
    }
}
