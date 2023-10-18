using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Gymbex.Blazor.Utils
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;   
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
            {
                // Brak tokenu, więc użytkownik nie jest uwierzytelniony
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            else
            {
                // Weryfikacja tokenu i stworzenie ClaimsPrincipal
                // (Zakładając, że masz metodę ParseClaimsFromJwt() do przetwarzania tokenu)
                var claims = ParseClaimsFromJwt(token);
                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
        }
        private IEnumerable<Claim> ParseClaimsFromJwt(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            if (jwtHandler.CanReadToken(token))
            {
                var tokenRead = jwtHandler.ReadJwtToken(token);
                var claims = tokenRead.Claims;
                return claims;
            }
            else
            {
                // Token JWT jest niepoprawny, więc zwracamy pustą listę roszczeń.
                return new List<Claim>();
            }
        }
    }
}
