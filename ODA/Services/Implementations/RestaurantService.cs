using Microsoft.EntityFrameworkCore;
using ODA.Context;
using ODA.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        ApplicationDbContext Db { get; set; }

        public RestaurantService(ApplicationDbContext db)
        {
            this.Db = db;
        }
        public void Add(Restaurant restaurant)
        {
            Db.Restaurants.Add(restaurant);
            Db.SaveChanges();
        }

        public Task AddAsync(Restaurant restaurant)
        {
            return Task.Run(() =>
            {
                Add(restaurant);
            });
        }

        public IEnumerable<Restaurant> GetAll(string location = null)
        {
            if (string.IsNullOrWhiteSpace(location))
                return Db.Restaurants.Where(x => x.Location.ToLower().Contains(location)).AsNoTracking().ToList();
            return Db.Restaurants.AsNoTracking().ToList();
        }
        public IEnumerable<Restaurant> GetAllByMerchantId(string merchantId)
        {
            return Db.Restaurants.Where(x => x.MerchantId == merchantId).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Restaurant>> GetAllAsync(string location = null)
        {
            return Task.Run(() =>
            {
                return GetAll(location);
            });
        }
        public Task<IEnumerable<Restaurant>> GetAllByMerchantIdAsync(string merchantId)
        {
            return Task.Run(() =>
            {
                return GetAllByMerchantId(merchantId);
            });
        }

        public Restaurant Get(int Id)
        {
            return Db.Restaurants.Include(x => x.Items).FirstOrDefault(x => x.Id == Id);
        }

        public Task<Restaurant> GetAsync(int Id)
        {
            return Task.Run(() =>
            {
                return Get(Id);
            });
        }

        public void Update(Restaurant restaurant)
        {
            Db.Entry(restaurant).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Task UpdateAsync(Restaurant restaurant)
        {
            return Task.Run(() =>
            {
                Update(restaurant);
            });
        }

        public void Remove(Restaurant restaurant)
        {
            Db.Restaurants.Remove(restaurant);
            Db.SaveChanges();
        }

        public Task RemoveAsync(Restaurant restaurant)
        {
            return Task.Run(() =>
            {
                Remove(restaurant);
            });
        }

        public void Remove(int Id)
        {
            var restaurant = Get(Id);
            Remove(restaurant);
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
