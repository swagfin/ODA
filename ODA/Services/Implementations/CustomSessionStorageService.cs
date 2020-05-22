using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class CustomSessionStorageService : ICustomSessionStorageService
    {
        private IJSRuntime js { get; set; }

        public CustomSessionStorageService(IJSRuntime runtime)
        {
            js = runtime;
        }

        public void SetItem(string key, string value)
        {
            //localStorage.setItem(key, value);
            js.InvokeVoidAsync("localStorage.setItem", key, value);
        }
        public async Task<string> GetItem(string key)
        {
            //return localStorage.getItem(key);
            return await js.InvokeAsync<string>("localStorage.getItem", key);
        }
    }
}
