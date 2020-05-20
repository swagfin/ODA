using ODA.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Client.Services
{
    public interface IItemCategoryService
    {
        Task AddAsync(ItemCategoryViewModel itemCategory);
        Task<IEnumerable<ItemCategoryViewModel>> GetAllAsync();
        Task<ItemCategoryViewModel> GetAsync(int Id);
        Task UpdateAsync(ItemCategoryViewModel itemCategory);
        Task RemoveAsync(int Id);
        Task RemoveAsync(ItemCategoryViewModel itemCategory);
    }
}
