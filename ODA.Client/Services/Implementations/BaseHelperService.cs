using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Client.Services.Implementations
{
    public class BaseHelperService : IBaseHelperService
    {
        public string GetAuthenticationApi(string endpoint)
        {
            //Hard Copy
            return $"https://localhost:44312/api/{endpoint}";

        }

        public string GetServerApi(string endpoint)
        {
            return $"https://localhost:44312/api/{endpoint}";
        }
    }
}
