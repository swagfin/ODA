using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Client.Services
{
    public interface ISessionStorageService
    {
        void SetItem(string key, string value);
        Task<string> GetItem(string key);
    }
}
