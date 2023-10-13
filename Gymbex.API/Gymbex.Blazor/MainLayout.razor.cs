using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor
{
    public partial class MainLayout
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        private void RedirectToSignUp()
        {
            NavigationManager.NavigateTo("/signup");
        }
    }
}
