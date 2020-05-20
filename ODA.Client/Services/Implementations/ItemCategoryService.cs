using Microsoft.AspNetCore.Components;
using ODA.Client.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ODA.Client.Services.Implementations
{
    public class ItemCategoryService : IItemCategoryService
    {
        private HttpClient Api { get; }
        private IBaseHelperService BaseHelper { get; }
        public ItemCategoryService(IBaseHelperService helper, HttpClient httpClient)
        {
            Api = httpClient;
            BaseHelper = helper;
        }

        public Task AddAsync(ItemCategoryViewModel itemCategory)
        {
            return Api.PostJsonAsync(BaseHelper.GetServerApi("ItemCategories"), itemCategory);
        }

        public Task<IEnumerable<ItemCategoryViewModel>> GetAllAsync()
        {
            return Api.GetJsonAsync<IEnumerable<ItemCategoryViewModel>>(BaseHelper.GetServerApi("ItemCategories"));
        }

        public Task<ItemCategoryViewModel> GetAsync(int Id)
        {
            return Api.GetJsonAsync<ItemCategoryViewModel>(BaseHelper.GetServerApi($"ItemCategories/{Id}"));
        }

        public Task UpdateAsync(ItemCategoryViewModel itemCategory)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(ItemCategoryViewModel itemCategory)
        {
            throw new System.NotImplementedException();
        }
    }
}
