using Microsoft.EntityFrameworkCore;
using ODA.DataAccess;
using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class ItemService : IItemService
    {
        ApplicationDbContext Db { get; set; }

        public ItemService(ApplicationDbContext db)
        {
            this.Db = db;
        }
        public void Add(Item item)
        {
            Db.Items.Add(item);
            Db.SaveChanges();
        }

        public Task AddAsync(Item item)
        {
            return Task.Run(() =>
            {
                Add(item);
            });
        }

        public IEnumerable<Item> GetAll()
        {
            return Db.Items.Include(x => x.Restaurant).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Item>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public Item Get(int Id)
        {
            return Db.Items.FirstOrDefault(x => x.ItemId == Id);
        }

        public Task<Item> GetAsync(int Id)
        {
            return Task.Run(() =>
            {
                return Get(Id);
            });
        }

        public void Update(Item item)
        {
            Db.Update(item);
            Db.SaveChanges();
        }

        public Task UpdateAsync(Item item)
        {
            return Task.Run(() =>
            {
                Update(item);
            });
        }

        public void Remove(Item item)
        {
            Db.Items.Remove(item);
            Db.SaveChanges();
        }

        public Task RemoveAsync(Item item)
        {
            return Task.Run(() =>
            {
                Remove(item);
            });
        }

        public void Remove(int Id)
        {
            var item = Get(Id);
            Remove(item);
        }

        public Task RemoveAsync(int Id)
        {
            return Task.Run(() =>
            {
                Remove(Id);
            });
        }

        public IEnumerable<Item> GetAllByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return Db.Items.Include(x => x.Restaurant).Where(x => x.Restaurant != null).AsNoTracking().ToList();
            return Db.Items.Include(x => x.Restaurant).Where(x => x.Restaurant != null && x.Restaurant.Location.ToLower().Contains(location)).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Item>> GetAllByLocationAsync(string location)
        {
            return Task.Run(() =>
            {
                return GetAllByLocation(location);
            });
        }
    }
}
