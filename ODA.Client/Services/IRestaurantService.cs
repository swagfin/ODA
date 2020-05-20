using ODA.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Client.Services
{
    public interface IRestaurantService
    {
        Task AddAsync(RestaurantViewModel restaurant);
        Task<IEnumerable<RestaurantViewModel>> GetAllAsync(string location = null);
        Task<RestaurantViewModel> GetAsync(int Id);
        Task UpdateAsync(RestaurantViewModel restaurant);
        Task RemoveAsync(int Id);
        Task RemoveAsync(RestaurantViewModel restaurant);
    }
}
