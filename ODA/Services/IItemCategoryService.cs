using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IItemCategoryService
    {
        Task AddAsync(ItemCategory itemCategory);
        Task<IEnumerable<ItemCategory>> GetAllAsync();
        Task<ItemCategory> GetAsync(int Id);
        Task UpdateAsync(ItemCategory itemCategory);
        Task RemoveAsync(int Id);
        Task RemoveAsync(ItemCategory itemCategory);
    }
}
