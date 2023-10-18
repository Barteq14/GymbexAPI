using Gymbex.Blazor.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace Gymbex.Blazor.Components
{
    public partial class AuthenticationBanner
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
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
    }
}
