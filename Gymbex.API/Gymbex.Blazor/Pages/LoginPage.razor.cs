using Gymbex.Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages
{
    public partial class LoginPage
    {
        private SignInCommand loginModel = new SignInCommand();
        private bool ShowErrors;
        private string Error = "";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("scrollToDiv");
            }
        }

        private async Task HandleLogin()
        {
            ShowErrors = false;

            var result = await AuthService.Login(loginModel);

            if (!string.IsNullOrEmpty(result.Token))
            {
                NavigationManager.NavigateTo("/",true);
            }
            else
            {
                Error = result.Error;
                ShowErrors = true;
            }
        }
    }
}
