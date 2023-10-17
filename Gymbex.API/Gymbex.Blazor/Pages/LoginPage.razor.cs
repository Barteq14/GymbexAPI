using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Pages
{
    public partial class LoginPage
    {
        private SignInCommand loginModel = new SignInCommand();
        private bool ShowErrors;
        private string Error = "";

        private async Task HandleLogin()
        {
            ShowErrors = false;

            var result = await AuthService.Login(loginModel);

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                NavigationManager.NavigateTo("/",true);
            }
            else
            {
                ShowErrors = true;
            }
        }
    }
}
