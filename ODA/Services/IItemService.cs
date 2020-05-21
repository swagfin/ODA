using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IItemService
    {
        Task AddAsync(Item item);
        Task<IEnumerable<Item>> GetAllAsync();
        Task<IEnumerable<Item>> GetAllByLocationAsync(string location);
        Task<Item> GetAsync(int Id);
        Task UpdateAsync(Item item);
        Task RemoveAsync(int Id);
        Task RemoveAsync(Item item);
    }
}
