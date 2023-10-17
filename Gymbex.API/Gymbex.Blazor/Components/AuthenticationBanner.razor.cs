using Gymbex.Blazor.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
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

        private void Register()
        {
            NavigationManager.NavigateTo("/register");
        }

        private void Login()
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}
