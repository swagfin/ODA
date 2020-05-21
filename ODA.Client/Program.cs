using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authorization;
using ODA.Client.Auth;
using ODA.Client.Services;
using ODA.Client.Services.Implementations;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ODA.Client
{
    public class Program
    {
        private static void ConfigureServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IBaseHelperService, BaseHelperService>();
            builder.Services.AddScoped<ISessionStorageService, SessionStorageService>();
            builder.Services.AddScoped<IItemCategoryService, ItemCategoryService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IMapPopularPlaceService, MapPopularPlaceService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationStateProvider,ODAAuthenticationStateProvider>();
        }
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            ConfigureServices(builder);
            await builder.Build().RunAsync();
        }


    }
}
