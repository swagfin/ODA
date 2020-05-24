using Microsoft.EntityFrameworkCore;
using ODA.Context;
using ODA.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class OrderService : IOrderService
    {
        ApplicationDbContext Db { get; set; }

        public OrderService(ApplicationDbContext db)
        {
            this.Db = db;
        }
        public void ProcessOrder(Order order)
        {
            Db.Orders.Add(order);
            Db.SaveChanges();
        }

        public Task ProcessOrderAsync(Order order)
        {
            return Task.Run(() =>
            {
                ProcessOrder(order);
            });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Db.Orders.Include(x => x.Restaurant).Include(x => x.OrderItems).OrderByDescending(x => x.Id).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return Task.Run(() =>
            {
                return GetAllOrders();
            });
        }

        public Order GetOrderById(int Id)
        {
            return Db.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public Task<Order> GetOrderByIdAsync(int Id)
        {
            return Task.Run(() =>
            {
                return GetOrderById(Id);
            });
        }

        public void UpdateOrder(Order order)
        {
            Db.Entry(order).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Task UpdateOrderAsync(Order order)
        {
            return Task.Run(() =>
            {
                UpdateOrder(order);
            });
        }

        public void RemoveOrder(Order order)
        {
            Db.Orders.Remove(order);
            Db.SaveChanges();
        }

        public Task RemoveOrderAsync(Order order)
        {
            return Task.Run(() =>
            {
                RemoveOrder(order);
            });
        }

        public void RemoveOrder(int Id)
        {
            var order = GetOrderById(Id);
            RemoveOrder(order);
        }

        public Task RemoveOrderAsync(int Id)
        {
            return Task.Run(() =>
            {
                RemoveOrder(Id);
            });
        }

        public IEnumerable<Order> GetAllByCustomerId(int CustomerId, OrderStatus status)
        {
            return Db.Orders.Include(x => x.Restaurant).Include(x => x.OrderItems).Where(x => x.CustomerId == CustomerId && x.OrderStatus == status.ToString()).OrderByDescending(x => x.Id).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId, OrderStatus status)
        {
            return Task.Run(() =>
            {
                return GetAllByCustomerId(customerId, status);
            });
        }

        public void CancelOrder(int orderId)
        {
            var foundOrder = GetOrderById(orderId);
            if (foundOrder != null)
            {
                foundOrder.OrderStatus = OrderStatus.Cancelled.ToString();
                //Do something when user cancelles an Order e.g. Charges
                Db.SaveChanges();
            }
        }
        public Task CancelOrderAsync(Order order)
        {
            return Task.Run(() =>
            {
                CancelOrder(order.Id);
            });
        }

        public Task CancelOrderAsync(int orderId)
        {
            return Task.Run(() =>
            {
                CancelOrder(orderId);
            });
        }

        public bool ValidateOrder(int orderId)
        {
            var id = Db.Orders.Select(x => x.Id).Where(x => x == orderId).FirstOrDefault();
            if (id != 0)
                return true;
            return false;
        }
        public Task<bool> ValidateOrderAsync(Order order)
        {
            return Task.Run(() =>
            {
                return ValidateOrder(order.Id);
            });
        }

        public Task<bool> ValidateOrderAsync(int orderId)
        {
            return Task.Run(() =>
            {
                return ValidateOrder(orderId);
            });
        }

    }
}
