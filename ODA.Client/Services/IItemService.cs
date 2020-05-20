using ODA.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Client.Services
{
    public interface IItemService
    {
        Task AddAsync(ItemViewModel item);
        Task<IEnumerable<ItemViewModel>> GetAllAsync();
        Task<IEnumerable<ItemViewModel>> GetAllByLocationAsync(string location);
        Task<ItemViewModel> GetAsync(int Id);
        Task UpdateAsync(ItemViewModel item);
        Task RemoveAsync(int Id);
        Task RemoveAsync(ItemViewModel item);
    }
}
