using Microsoft.EntityFrameworkCore;
using ODA.Context;
using ODA.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class MapPopularPlaceService : IMapPopularPlaceService
    {
        ApplicationDbContext Db { get; set; }

        public MapPopularPlaceService(ApplicationDbContext db)
        {
            this.Db = db;
        }
        public void Add(MapPopularPlace mapPopularPlace)
        {
            Db.MapPopularPlaces.Add(mapPopularPlace);
            Db.SaveChanges();
        }

        public Task AddAsync(MapPopularPlace mapPopularPlace)
        {
            return Task.Run(() =>
            {
                Add(mapPopularPlace);
            });
        }

        public IEnumerable<MapPopularPlace> GetAll()
        {
            return Db.MapPopularPlaces.AsNoTracking().ToList().OrderByDescending(x => x.PopularityRank);
        }

        public Task<IEnumerable<MapPopularPlace>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public MapPopularPlace Get(string place)
        {
            return Db.MapPopularPlaces.FirstOrDefault(x => x.Place == place);
        }

        public Task<MapPopularPlace> GetAsync(string place)
        {
            return Task.Run(() =>
            {
                return Get(place);
            });
        }

        public void Update(MapPopularPlace mapPopularPlace)
        {
            Db.Entry(mapPopularPlace).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Task UpdateAsync(MapPopularPlace mapPopularPlace)
        {
            return Task.Run(() =>
            {
                Update(mapPopularPlace);
            });
        }

        public void Remove(MapPopularPlace mapPopularPlace)
        {
            Db.MapPopularPlaces.Remove(mapPopularPlace);
            Db.SaveChanges();
        }

        public Task RemoveAsync(MapPopularPlace mapPopularPlace)
        {
            return Task.Run(() =>
            {
                Remove(mapPopularPlace);
            });
        }

        public void Remove(string place)
        {
            var mapPopularPlace = Get(place);
            Remove(mapPopularPlace);
        }

        public Task RemoveAsync(string place)
        {
            return Task.Run(() =>
            {
                Remove(place);
            });
        }

    }
}
