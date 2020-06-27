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
            //Update the Customer Order
            if (order.CustomerId != null)
            {
                var customer = Db.Customers.Where(x => x.Id == order.CustomerId).FirstOrDefault();
                customer.PlacedOrders += 1;
                Db.SaveChanges();
            }
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
            return Db.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.Id == Id);
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

        public IEnumerable<Order> GetAllByCustomerId(string CustomerId)
        {
            return Db.Orders.Include(x => x.Restaurant).Include(x => x.OrderItems).Where(x => x.CustomerId == CustomerId).OrderByDescending(x => x.Id).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return Task.Run(() =>
            {
                return GetAllByCustomerId(customerId);
            });
        }
        //Cancel By Reference Number
        public void CancelOrder(string orderRefNo)
        {
            if (string.IsNullOrWhiteSpace(orderRefNo))
                return;
            var foundOrder = Db.Orders.Where(x => x.OrderRef == orderRefNo).FirstOrDefault();
            if (foundOrder != null)
            {
                foundOrder.OrderStatus = OrderStatus.Cancelled.ToString();
                Db.SaveChanges();
                //Do something when user cancelles an Order e.g. Charges, Notifications
                if (foundOrder.CustomerId != null)
                {
                    var customer = Db.Customers.Where(x => x.Id == foundOrder.CustomerId).FirstOrDefault();
                    customer.CancelledOrders += 1;
                    Db.SaveChanges();
                }
            }
        }
        public Task CancelOrderAsync(string orderRefNo)
        {
            return Task.Run(() =>
            {
                CancelOrder(orderRefNo);
            });
        }

        public void UpdateOrderStatus(OrderStatus orderStatus, int orderId)
        {
            var foundOrder = Db.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            if (foundOrder != null)
            {
                foundOrder.OrderStatus = orderStatus.ToString();
                Db.SaveChanges();
                //Notification Status Order Changed

                if (foundOrder.CustomerId != null && orderStatus == OrderStatus.Cancelled)
                {
                    var customer = Db.Customers.Where(x => x.Id == foundOrder.CustomerId).FirstOrDefault();
                    customer.CancelledOrders += 1;
                    Db.SaveChanges();
                }
            }
        }

        public Task UpdateOrderStatusAsync(OrderStatus orderStatus, int orderId)
        {
            return Task.Run(() =>
            {
                UpdateOrderStatus(orderStatus, orderId);
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
