using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Server.Services
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        Task AddAsync(Customer customer);
        IEnumerable<Customer> GetAll();
        Task<IEnumerable<Customer>> GetAllAsync();
        Customer Get(int Id);
        Task<Customer> GetAsync(int Id);
        void Update(Customer customer);
        Task UpdateAsync(Customer customer);
        void Remove(int Id);
        Task RemoveAsync(int Id);
        void Remove(Customer customer);
        Task RemoveAsync(Customer customer);
    }
}
