using Microsoft.EntityFrameworkCore;
using ODA.Auth;
using ODA.Context;
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

        public Customer VerifyCredentials(string usernameOrEmail, string password)
        {
            return Db.Customers.Where(x => x.PhoneNumber == usernameOrEmail && x.Password == password || x.EmailAddress == usernameOrEmail && x.Password == password).AsNoTracking().FirstOrDefault();
        }
        public Task<Customer> VerifyCredentialsAsync(string usernameOrEmail, string password)
        {
            return Task.Run(() =>
            {
                return VerifyCredentials(usernameOrEmail, password);
            });
        }
        public bool VerifyAuthCode(string code, string usernameOrEmail)
        {
            var user = Db.Customers.Where(x => x.PhoneNumber == usernameOrEmail && x.VerificationCode == code || x.EmailAddress == usernameOrEmail && x.VerificationCode == code).FirstOrDefault();
            if (user != null)
            {
                //Update Account that its verified
                user.IsAccountConfirmed = true;
                Db.SaveChanges();
                return true;
            }
            return false;
        }
        public Task<bool> VerifyAuthCodeAsync(string code, string usernameOrEmail)
        {
            return Task.Run(() =>
            {
                return VerifyAuthCode(code, usernameOrEmail);
            });
        }

        public bool VerifyExists(string phoneNumber, string emailAddress)
        {
            return Db.Customers.Where(x => x.PhoneNumber == phoneNumber || x.EmailAddress == emailAddress).AsNoTracking().FirstOrDefault() != null;
        }
        public Task<bool> VerifyExistsAsync(string phoneNumber, string emailAddress)
        {
            return Task.Run(() =>
            {
                return VerifyExists(phoneNumber, emailAddress);
            });
        }

        public Customer GetByEmail(string emailAddress)
        {
            return Db.Customers.AsNoTracking().FirstOrDefault(x => x.EmailAddress == emailAddress);
        }
        public Task<Customer> GetByEmailAsync(string emailAddress)
        {
            return Task.Run(() =>
            {
                return GetByEmail(emailAddress);
            });
        }
    }
}
