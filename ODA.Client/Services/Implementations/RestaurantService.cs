using Microsoft.AspNetCore.Components;
using ODA.Client.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ODA.Client.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private HttpClient Api { get; }
        private IBaseHelperService BaseHelper { get; }
        public RestaurantService(IBaseHelperService helper, HttpClient httpClient)
        {
            Api = httpClient;
            BaseHelper = helper;
        }

        public Task AddAsync(RestaurantViewModel restaurant)
        {
            return Api.PostJsonAsync(BaseHelper.GetServerApi("Restaurants"), restaurant);
        }

        public Task<IEnumerable<RestaurantViewModel>> GetAllAsync(string location = null)
        {
            return Api.GetJsonAsync<IEnumerable<RestaurantViewModel>>(BaseHelper.GetServerApi("Restaurants"));
        }

        public Task<RestaurantViewModel> GetAsync(int Id)
        {
            return Api.GetJsonAsync<RestaurantViewModel>(BaseHelper.GetServerApi($"Restaurants/{Id}"));
        }

        public Task UpdateAsync(RestaurantViewModel restaurant)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(RestaurantViewModel restaurant)
        {
            throw new System.NotImplementedException();
        }
    }
}
