using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IOrderService
    {
        void Add(Order order);
        Task AddAsync(Order order);
        IEnumerable<Order> GetAll();
        Task<IEnumerable<Order>> GetAllAsync();
        Order Get(int Id);
        Task<Order> GetAsync(int Id);
        void Update(Order order);
        Task UpdateAsync(Order order);
        void Remove(int Id);
        Task RemoveAsync(int Id);
        void Remove(Order order);
        Task RemoveAsync(Order order);
    }
}
