using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IRestaurantService
    {
        Task AddAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllAsync(string location = null);
        Task<Restaurant> GetAsync(int Id);
        Task UpdateAsync(Restaurant restaurant);
        Task RemoveAsync(int Id);
        Task RemoveAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllByMerchantIdAsync(string merchantId);
    }
}
