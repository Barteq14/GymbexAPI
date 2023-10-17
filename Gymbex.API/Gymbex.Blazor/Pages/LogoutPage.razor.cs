namespace Gymbex.Blazor.Pages
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
