using Microsoft.EntityFrameworkCore;
using ODA.DataAccess;
using ODA.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class ItemCategoryService : IItemCategoryService
    {
        ApplicationDbContext Db { get; set; }

        public ItemCategoryService(ApplicationDbContext db)
        {
            this.Db = db;
        }
        public void Add(ItemCategory itemCategory)
        {
            Db.ItemCategories.Add(itemCategory);
            Db.SaveChanges();
        }

        public Task AddAsync(ItemCategory itemCategory)
        {
            return Task.Run(() =>
            {
                Add(itemCategory);
            });
        }

        public IEnumerable<ItemCategory> GetAll()
        {
            return Db.ItemCategories.AsNoTracking().ToList();
        }

        public Task<IEnumerable<ItemCategory>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public ItemCategory Get(int Id)
        {
            return Db.ItemCategories.FirstOrDefault(x => x.Id == Id);
        }

        public Task<ItemCategory> GetAsync(int Id)
        {
            return Task.Run(() =>
            {
                return Get(Id);
            });
        }

        public void Update(ItemCategory itemCategory)
        {
            Db.Entry(itemCategory).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Task UpdateAsync(ItemCategory itemCategory)
        {
            return Task.Run(() =>
            {
                Update(itemCategory);
            });
        }

        public void Remove(ItemCategory itemCategory)
        {
            Db.ItemCategories.Remove(itemCategory);
            Db.SaveChanges();
        }

        public Task RemoveAsync(ItemCategory itemCategory)
        {
            return Task.Run(() =>
            {
                Remove(itemCategory);
            });
        }

        public void Remove(int Id)
        {
            var itemCategory = Get(Id);
            Remove(itemCategory);
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
