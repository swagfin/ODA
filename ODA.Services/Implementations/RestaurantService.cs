using Microsoft.EntityFrameworkCore;
using ODA.DataAccess;
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

        public IEnumerable<Restaurant> GetAll()
        {
            return Db.Restaurants.AsNoTracking().ToList();
        }

        public Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public Restaurant Get(int Id)
        {
            return Db.Restaurants.FirstOrDefault(x => x.Id == Id);
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
