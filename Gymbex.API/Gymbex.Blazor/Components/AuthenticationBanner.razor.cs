using Blazored.LocalStorage;
using Gymbex.Blazor.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Gymbex.Blazor.Components
{
    public partial class AuthenticationBanner
    {
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public ILocalStorageService LocalStorageService { get; set; }

        private void Logout()
        {
            NavigationManager.NavigateTo("/logout",true);
        }

        private async Task Register()
        {
            NavigationManager.NavigateTo("/register");
        }

        private async Task Login()
        {
            NavigationManager.NavigateTo("/login");
        }

        private async void MyAccount()
        {
            var token = await LocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();

            var jwt = new JwtSecurityToken(token);

            var uniqueName = jwt.Claims.FirstOrDefault(c => c.Type == "unique_name").Value;

            var id = Guid.Parse(uniqueName);

            NavigationManager.NavigateTo($"/myAccount/{id}");
        }
    }
}
