using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IItemService
    {
        void Add(Item item);
        Task AddAsync(Item item);
        IEnumerable<Item> GetAll();
        Task<IEnumerable<Item>> GetAllAsync();
        IEnumerable<Item> GetAllByLocation(string location);
        Task<IEnumerable<Item>> GetAllByLocationAsync(string location);
        Item Get(int Id);
        Task<Item> GetAsync(int Id);
        void Update(Item item);
        Task UpdateAsync(Item item);
        void Remove(int Id);
        Task RemoveAsync(int Id);
        void Remove(Item item);
        Task RemoveAsync(Item item);
    }
}
