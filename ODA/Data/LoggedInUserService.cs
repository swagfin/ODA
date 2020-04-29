using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Data
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private Customer Currentuser { get; set; }
        private DateTime SessionExpiresAt { get; set; } = DateTime.Now;
        private int SessionExpiryInterval { get; set; } = 3600;
        private bool LogUserInfo { get; set; }


        private void RenewSession()
        {
            SessionExpiresAt = DateTime.Now.AddMinutes(SessionExpiryInterval);
        }
        public void StartSession(Customer loggedInUser)
        {
            if (loggedInUser == null)
                throw new Exception("Error! Session start Aborted. User account is null or is invalid");
            Currentuser = loggedInUser;
            RenewSession();
        }
        public Task StartSessionAsync(Customer loggedInUser)
        {
            return Task.Run(() =>
            {
                StartSession(loggedInUser);
            });
        }

        public void VerifyUserSession()
        {
            if (Currentuser == null || IsSessionExpired())
                throw new Exception("Oops! Session has Expired or account is not Authenticated. Please login to your account.");
            //Then Update Request Time
            SessionExpiresAt = DateTime.Now;
            RenewSession();
        }

        public void EndSession()
        {
            Currentuser = null;
        }

        public bool IsSessionExpired()
        {
            //Check if Last Request Time is Greater Than 30 Minutes
            if (DateTime.Now >= SessionExpiresAt)
                return true;
            return false;
        }


        public long GetSessionTokens()
        {
            return SessionExpiresAt.Ticks - DateTime.Now.Ticks;
        }

        public string GetUserFullName()
        {
            if (Currentuser == null)
                return string.Empty;
            return $"{Currentuser.FirstName} {Currentuser.LastName}".Trim();
        }

        public int GetUserId()
        {
            if (Currentuser == null)
                return 0;
            return Currentuser.Id;
        }

        public string GetUserMobilePhone()
        {
            return Currentuser.PrimaryMobile ?? string.Empty; ;
        }

        public void AddLog(string LoggInformation)
        {
            try
            {
                //log
            }
            catch (Exception)
            {

            }

        }

        public Task AddLogAsync(string LoggInformation)
        {
            return Task.Run(() =>
            {
                AddLog(LoggInformation);
            });

        }



    }
}

