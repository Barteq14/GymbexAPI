using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Pages
{
    public partial class RegisterPage
    {
        private Customer RegisterModel = new Customer();
        private bool ShowErrors;
        private IEnumerable<string>? Errors;

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
