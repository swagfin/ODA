using Microsoft.AspNetCore.Components;
using ODA.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ODA.Client.Services.Implementations
{
    public class ItemService : IItemService
    {
        private HttpClient Api { get; }
        private IBaseHelperService BaseHelper { get; }
        public ItemService(IBaseHelperService helper, HttpClient httpClient)
        {
            Api = httpClient;
            BaseHelper = helper;
        }

        public Task AddAsync(ItemViewModel item)
        {
            return Api.PostJsonAsync(BaseHelper.GetServerApi("Items"), item);
        }

        public Task<IEnumerable<ItemViewModel>> GetAllAsync()
        {
            return Api.GetJsonAsync<IEnumerable<ItemViewModel>>(BaseHelper.GetServerApi("Items"));
        }

        public Task<IEnumerable<ItemViewModel>> GetAllByLocationAsync(string location)
        {
            return Api.GetJsonAsync<IEnumerable<ItemViewModel>>(BaseHelper.GetServerApi($"Items"));
        }

        public Task<ItemViewModel> GetAsync(int Id)
        {
            return Api.GetJsonAsync<ItemViewModel>(BaseHelper.GetServerApi($"Items/{Id}"));
        }

        public Task UpdateAsync(ItemViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
