using Blazored.LocalStorage;
using Gymbex.Blazor.Security;
using Gymbex.Blazor.Utils;
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

        private async Task AdminPanel()
        {
            NavigationManager.NavigateTo("/adminPanel");
        }

        private async Task MyReservations()
        {
            NavigationManager.NavigateTo("/myReservations");
        }

        private async void MyAccount()
        {
            var id = await UserHelper.GetUserId(LocalStorageService);

            NavigationManager.NavigateTo($"/myAccount/{id}");
        }
    }
}
