using Gymbex.Blazor.Models;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages
{
    public partial class RegisterPage
    {
        private Customer RegisterModel = new Customer();
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
