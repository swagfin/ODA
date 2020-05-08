using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IRestaurantService
    {
        void Add(Restaurant restaurant);
        Task AddAsync(Restaurant restaurant);
        IEnumerable<Restaurant> GetAll(string location = null);
        Task<IEnumerable<Restaurant>> GetAllAsync(string location = null);
        Restaurant Get(int Id);
        Task<Restaurant> GetAsync(int Id);
        void Update(Restaurant restaurant);
        Task UpdateAsync(Restaurant restaurant);
        void Remove(int Id);
        Task RemoveAsync(int Id);
        void Remove(Restaurant restaurant);
        Task RemoveAsync(Restaurant restaurant);
    }
}
