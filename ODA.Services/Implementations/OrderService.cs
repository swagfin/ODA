using Microsoft.EntityFrameworkCore;
using ODA.DataAccess;
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
        public void Add(Order order)
        {
            Db.Orders.Add(order);
            Db.SaveChanges();
        }

        public Task AddAsync(Order order)
        {
            return Task.Run(() =>
            {
                Add(order);
            });
        }

        public IEnumerable<Order> GetAll()
        {
            return Db.Orders.AsNoTracking().ToList();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public Order Get(int Id)
        {
            return Db.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public Task<Order> GetAsync(int Id)
        {
            return Task.Run(() =>
            {
                return Get(Id);
            });
        }

        public void Update(Order order)
        {
            Db.Entry(order).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Task UpdateAsync(Order order)
        {
            return Task.Run(() =>
            {
                Update(order);
            });
        }

        public void Remove(Order order)
        {
            Db.Orders.Remove(order);
            Db.SaveChanges();
        }

        public Task RemoveAsync(Order order)
        {
            return Task.Run(() =>
            {
                Remove(order);
            });
        }

        public void Remove(int Id)
        {
            var order = Get(Id);
            Remove(order);
        }

        public Task RemoveAsync(int Id)
        {
            return Task.Run(() =>
            {
                Remove(Id);
            });
        }

    }
}
