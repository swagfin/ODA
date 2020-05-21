using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ODA.Auth
{
    public class ODAAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var authUserIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim("key1","someValue"),
                new Claim(ClaimTypes.Name,"George Wainaina"),
                new Claim(ClaimTypes.Email,"georgewainaina@gmail.com")
            });


            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(authUserIdentity)));
        }
    }
}
