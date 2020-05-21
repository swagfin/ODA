using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IMapPopularPlaceService
    {
        Task AddAsync(MapPopularPlace mapPopularPlace);
        Task<IEnumerable<MapPopularPlace>> GetAllAsync();
        Task<MapPopularPlace> GetAsync(string place);
        Task UpdateAsync(MapPopularPlace mapPopularPlace);
        Task RemoveAsync(string place);
        Task RemoveAsync(MapPopularPlace mapPopularPlace);
    }
}
