using Microsoft.AspNetCore.Components;
using ODA.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ODA.Client.Services.Implementations
{
    public class MapPopularPlaceService : IMapPopularPlaceService
    {
        private HttpClient Api { get; }
        private IBaseHelperService BaseHelper { get; }
        public MapPopularPlaceService(IBaseHelperService helper, HttpClient httpClient)
        {
            Api = httpClient;
            BaseHelper = helper;
        }

        public Task AddAsync(MapPopularPlaceViewModel mapPopularPlace)
        {
            return Api.PostJsonAsync(BaseHelper.GetServerApi("MapPopularPlaces"), mapPopularPlace);
        }
        public Task<IEnumerable<MapPopularPlaceViewModel>> GetAllAsync()
        {
            return Api.GetJsonAsync<IEnumerable<MapPopularPlaceViewModel>>(BaseHelper.GetServerApi("MapPopularPlaces"));
        }

        public Task<MapPopularPlaceViewModel> GetAsync(string place)
        {
            return Api.GetJsonAsync<MapPopularPlaceViewModel>(BaseHelper.GetServerApi($"MapPopularPlaces/{place}"));
        }

        public Task UpdateAsync(MapPopularPlaceViewModel mapPopularPlace)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string place)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(MapPopularPlaceViewModel mapPopularPlace)
        {
            throw new NotImplementedException();
        }
    }
}
