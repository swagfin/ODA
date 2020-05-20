using ODA.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Client.Services
{
    public interface IMapPopularPlaceService
    {
        Task AddAsync(MapPopularPlaceViewModel mapPopularPlace);
        Task<IEnumerable<MapPopularPlaceViewModel>> GetAllAsync();
        Task<MapPopularPlaceViewModel> GetAsync(string place);
        Task UpdateAsync(MapPopularPlaceViewModel mapPopularPlace);
        Task RemoveAsync(string place);
        Task RemoveAsync(MapPopularPlaceViewModel mapPopularPlace);
    }
}
