using Microsoft.EntityFrameworkCore;
using ODA.Entity;
using ODA.Server.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Server.Services.Implementations
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
            return Db.Items.AsNoTracking().ToList();
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
            Db.Entry(item).State = EntityState.Modified;
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

        public IEnumerable<Item> GetItemsLike(string foodLike)
        {
            return Db.Items.Include(x => x.Restaurant).Where(x => x.ItemName.ToLower().Contains(foodLike.ToLower()) || x.Category.Contains(foodLike)).AsNoTracking().ToList();
        }

        public Task<IEnumerable<Item>> GetItemsLikeAsync(string foodlike)
        {
            return Task.Run(() =>
            {
                return GetItemsLike(foodlike);
            });
        }
    }
}
