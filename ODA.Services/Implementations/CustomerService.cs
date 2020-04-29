using Microsoft.EntityFrameworkCore;
using ODA.DataAccess;
using ODA.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        ApplicationDbContext Db { get; set; }

        public CustomerService(ApplicationDbContext db)
        {
            this.Db = db;
        }
        public void Add(Customer customer)
        {
            Db.Customers.Add(customer);
            Db.SaveChanges();
        }

        public Task AddAsync(Customer customer)
        {
            return Task.Run(() =>
            {
                Add(customer);
            });
        }

        public IEnumerable<Customer> GetAll()
        {
            return Db.Customers.AsNoTracking().ToList();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public Customer Get(int Id)
        {
            return Db.Customers.FirstOrDefault(x => x.Id == Id);
        }

        public Task<Customer> GetAsync(int Id)
        {
            return Task.Run(() =>
            {
                return Get(Id);
            });
        }

        public void Update(Customer customer)
        {
            Db.Entry(customer).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Task UpdateAsync(Customer customer)
        {
            return Task.Run(() =>
            {
                Update(customer);
            });
        }

        public void Remove(Customer customer)
        {
            Db.Customers.Remove(customer);
            Db.SaveChanges();
        }

        public Task RemoveAsync(Customer customer)
        {
            return Task.Run(() =>
            {
                Remove(customer);
            });
        }

        public void Remove(int Id)
        {
            var customer = Get(Id);
            Remove(customer);
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
