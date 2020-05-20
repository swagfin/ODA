using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Client.Services
{
    public interface IBaseHelperService
    {
        string GetServerApi(string endpoint);
        string GetAuthenticationApi(string endpoint);
    }
}
