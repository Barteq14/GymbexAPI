using Gymbex.Blazor.Models;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages.Authentication
{
    public partial class RegisterPage
    {
        private CustomerRegisterModel RegisterModel = new CustomerRegisterModel();
        private bool ShowErrors;
        private string Error;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("scrollToDiv");
            }
        }

        private async Task HandleRegistration()
        {
            ShowErrors = false;

            var result = await AuthService.Register(RegisterModel);

            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                Error = result.Error;
                ShowErrors = true;
            }
        }
    }
}
