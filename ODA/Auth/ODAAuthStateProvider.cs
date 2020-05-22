using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using ODA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace ODA.Auth
{
    public class ODAAuthStateProvider : AuthenticationStateProvider
    {
        private string USER_SESSION_OBJECT_KEY { get; }
        private string USER_SESSION_ENCRYPTION_KEY { get; }
        private ISessionStorageService storageService;
        private IEncryptionAlgorithimService encryptService;

        public ODAAuthStateProvider(ISessionStorageService storageService, IEncryptionAlgorithimService algorithimService)
        {
            this.storageService = storageService;
            this.encryptService = algorithimService;
            USER_SESSION_OBJECT_KEY = ODAConstants.userId.ToString();
            //Hard Coded the Encrption Key
            USER_SESSION_ENCRYPTION_KEY = "5a1b2aecd5a5027963c2b9c6e1f0be6B";
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

            try
            {
                string encryptedObj = await storageService.GetItemAsync<string>(USER_SESSION_OBJECT_KEY);
                // no active user session found!
                if (string.IsNullOrEmpty(encryptedObj))
                    return null;
                //else Decypt
                string decryptedObj = encryptService.Decrypt(encryptedObj, this.USER_SESSION_ENCRYPTION_KEY);
                return JsonConvert.DeserializeObject<User>(decryptedObj);
            }
            catch (Exception)
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



        private async Task SetUserSession(User user)
        {
            //Serialize
            string userString = JsonConvert.SerializeObject(user);
            //Encrpt
            string userEncrptedString = encryptService.Encrypt(userString, this.USER_SESSION_ENCRYPTION_KEY);
            //Save in Session
            await storageService.SetItemAsync(USER_SESSION_OBJECT_KEY, userEncrptedString);
        }

        private Task<AuthenticationState> GenerateAuthenticationState(User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }, "apiauth_type");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));



    }
}
