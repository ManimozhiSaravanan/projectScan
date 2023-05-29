using BAApp.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Drawing.Text;
using System.Security.Claims;

namespace BAApp.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
       

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role,userSession.Role)
                }, "CusomAuth"));
                    return await Task.FromResult(new AuthenticationState(claimsprincipal));
                }
            catch {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
         
            }
        public  async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsprincipal;
            if(userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                { 
                     new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role,userSession.Role)
            }));
        }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsprincipal = _anonymous;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsprincipal)));
        }
    }
}
