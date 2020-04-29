using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IItemCategoryService
    {
        void Add(ItemCategory itemCategory);
        Task AddAsync(ItemCategory itemCategory);
        IEnumerable<ItemCategory> GetAll();
        Task<IEnumerable<ItemCategory>> GetAllAsync();
        ItemCategory Get(int Id);
        Task<ItemCategory> GetAsync(int Id);
        void Update(ItemCategory itemCategory);
        Task UpdateAsync(ItemCategory itemCategory);
        void Remove(int Id);
        Task RemoveAsync(int Id);
        void Remove(ItemCategory itemCategory);
        Task RemoveAsync(ItemCategory itemCategory);
    }
}
