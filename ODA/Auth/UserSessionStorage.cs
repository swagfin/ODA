using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Auth
{
    public class UserSessionStorage
    {
        private User CurrentSession { get; set; }
        public User User
        {
            get
            {
                return CurrentSession;
            }
        }
        public void SignInUser(User user)
        {
            CurrentSession = user;
            CurrentSession.DateLoggedIn = DateTime.Now;
        }
        public void SignOutUser()
        {
            CurrentSession = null;
        }

        public bool IsLoggedIn()
        {
            if (CurrentSession != null)
            {
                return true;
            }
            return false;
        }


    }
}
