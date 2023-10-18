using Gymbex.Blazor.Models;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages
{
    public partial class RegisterPage
    {
        private Customer RegisterModel = new Customer();
        private bool ShowErrors;
        private IEnumerable<string>? Errors;

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

            if (result.Successful)
            {
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                Errors = result.Errors;
                ShowErrors = true;
            }
        }
    }
}
