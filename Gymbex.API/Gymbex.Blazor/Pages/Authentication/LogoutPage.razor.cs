namespace Gymbex.Blazor.Pages.Authentication
{
    public partial class LogoutPage
    {
        protected override async Task OnInitializedAsync()
        {
            await AuthService.Logout();
            NavigationManager.NavigateTo("/",true);
        }
    }
}
