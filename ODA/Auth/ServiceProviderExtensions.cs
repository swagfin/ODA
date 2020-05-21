using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Auth
{
    public static class ServiceProviderExtensions
    {
        public static T Get<T>(this IServiceProvider serviceProvider) => (T)serviceProvider.GetService(typeof(T).BaseType);
    }
}
