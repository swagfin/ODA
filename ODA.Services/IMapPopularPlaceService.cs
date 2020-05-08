using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IMapPopularPlaceService
    {
        void Add(MapPopularPlace mapPopularPlace);
        Task AddAsync(MapPopularPlace mapPopularPlace);
        IEnumerable<MapPopularPlace> GetAll();
        Task<IEnumerable<MapPopularPlace>> GetAllAsync();
        MapPopularPlace Get(string place);
        Task<MapPopularPlace> GetAsync(string place);
        void Update(MapPopularPlace mapPopularPlace);
        Task UpdateAsync(MapPopularPlace mapPopularPlace);
        void Remove(string place);
        Task RemoveAsync(string place);
        void Remove(MapPopularPlace mapPopularPlace);
        Task RemoveAsync(MapPopularPlace mapPopularPlace);
    }
}
