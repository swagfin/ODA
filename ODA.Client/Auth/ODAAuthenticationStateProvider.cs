using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ODA.Client.Auth
{
    public class ODAAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var demoAccountIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim("key1","value1"), //Sample of Claims // The Belong to u
                new Claim(ClaimTypes.Name,"George Wainaina"), //Name 
                new Claim(ClaimTypes.Email,"georgewainaina@gmail.com"),
                new Claim(ClaimTypes.Role,"Admin") //use this in Components specific Role
            });
            //You Can Use 
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(demoAccountIdentity)));
            //return await Task.Run(() =>
            //{
            //    return new AuthenticationState(new ClaimsPrincipal(demoAccountIdentity));
            //});
        }
    }
}
