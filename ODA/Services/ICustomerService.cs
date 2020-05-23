using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface ICustomerService
    {
        Task AddAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> VerifyCredentialsAsync(string usernameOrEmail, string password);
        Task<Customer> GetAsync(int Id);
        Task UpdateAsync(Customer customer);
        Task RemoveAsync(int Id);
        Task RemoveAsync(Customer customer);
        Task<bool> VerifyAuthCodeAsync(string code, string usernameOrEmail);
        Task<bool> VerifyExistsAsync(string phoneNumber, string emailAddress);
    }
}
