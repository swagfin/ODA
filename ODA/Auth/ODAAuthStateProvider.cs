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
    public class ODAAuthStateProvider : AuthenticationStateProvider
    {
        //public override Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    var authUserIdentity = new ClaimsIdentity(new List<Claim>
        //    {
        //        new Claim("key1","someValue"),
        //        new Claim(ClaimTypes.Name,"George Wainaina"),
        //        new Claim(ClaimTypes.Email,"georgewainaina@gmail.com")
        //    });


        //    return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(authUserIdentity)));
        //}

        private const string USER_SESSION_OBJECT_KEY = "user_session_obj";

        private byte[] authenticationKey, cryptographyKey;
        private ISessionStorageService storageService;

        public ODAAuthStateProvider(ISessionStorageService storageService)
        {
            this.storageService = storageService;
            authenticationKey = AuthenticatedEncryption.AuthenticatedEncryption.NewKey();
            cryptographyKey = AuthenticatedEncryption.AuthenticatedEncryption.NewKey();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // read a possible user session object from the storage.
            User userSession = await GetUserSession();

            if (userSession != null)
                return await GenerateAuthenticationState(userSession);
            return await GenerateEmptyAuthenticationState();
        }
        public async Task<User> GetUserSession()
        {
            string encryptedObj = await storageService.GetItemAsync<string>(USER_SESSION_OBJECT_KEY);

            // no active user session found!
            if (string.IsNullOrEmpty(encryptedObj))
                return null;
            string decryptedObj = AuthenticatedEncryption.AuthenticatedEncryption.Decrypt(encryptedObj, cryptographyKey, authenticationKey);
            try
            {
                return JsonConvert.DeserializeObject<User>(decryptedObj);
            }
            catch
            {
                // user could have modified to local value, leading to an
                // invalid decrypted object. Hence, the user just did destory
                // his own session object. We need to clear it up.
                await LogoutAsync();
                return null;
            }
        }

        public async Task LoginAsync(User user)
        {
            // store the session information in the client's storage.
            await SetUserSession(user);

            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateAuthenticationState(user));
        }

        public async Task LogoutAsync()
        {
            // delete the user's session object.
            await SetUserSession(null);

            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
        }



        private async Task SetUserSession(User user) => await storageService.SetItemAsync(USER_SESSION_OBJECT_KEY,
            AuthenticatedEncryption.AuthenticatedEncryption.Encrypt(JsonConvert.SerializeObject(user), cryptographyKey, authenticationKey));

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
