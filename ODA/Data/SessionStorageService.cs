using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Data
{
    public class SessionStorageService : ISessionStorageService
    {
        private IJSRuntime js { get; set; }
        public SessionStorageService(IJSRuntime runtime)
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
