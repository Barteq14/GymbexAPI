using Gymbex.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

namespace Gymbex.Blazor.Components
{
    public partial class UserBanner
    {
        private string userDisplayName;

        //protected override async Task OnInitializedAsync()
        //{
        //    var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        //    var user = authState.User;

        //    userDisplayName = user.Claims.FirstOrDefault(c => c.Type == "Email")?.Value
        //        ?? user.Claims.FirstOrDefault().Issuer;
        //}
    }
}
