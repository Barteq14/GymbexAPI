using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.JSInterop;


namespace Gymbex.Blazor.Utils
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
      
        private ClaimsPrincipal _user;

        public void SetUser(ClaimsPrincipal user)
        {
            _user = user;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = _user?.Identity ?? new ClaimsIdentity();
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
