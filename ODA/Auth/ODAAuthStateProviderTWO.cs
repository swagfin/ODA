using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace ODA.Auth
{
    public class ODAAuthStateProviderTWO : AuthenticationStateProvider
    {
        private UserSessionStorage storageService;

        public ODAAuthStateProviderTWO(UserSessionStorage storageService)
        {
            this.storageService = storageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // read a possible user session object from the storage.
            User userSession = storageService.User;
            if (userSession != null)
                return await GenerateAuthenticationState(userSession);
            return await GenerateEmptyAuthenticationState();
        }

        public async Task LoginAsync(User user)
        {
            await Task.Run(() =>
            {
                storageService.SignInUser(user);
            });
            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateAuthenticationState(user));
        }

        public async Task LogoutAsync()
        {
            // delete the user's session object.
            await Task.Run(() =>
            {
                storageService.SignOutUser();
            });
            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
        }

        private Task<AuthenticationState> GenerateAuthenticationState(User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }, "apiauth_type");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));



    }
}
