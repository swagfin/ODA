using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Data
{
    /// <summary>
    /// This Interface provides Current Logged In User Account Helper
    /// </summary>
    public interface ILoggedInUserService
    {
        void AddLog(string LoggInformation);
        Task AddLogAsync(string LoggInformation);
        void EndSession();
        long GetSessionTokens();
        string GetUserFullName();
        int GetUserId();
        string GetUserMobilePhone();
        bool IsSessionExpired();
        void StartSession(Customer loggedInUser);
        Task StartSessionAsync(Customer loggedInUser);
        void VerifyUserSession();

    }
}
