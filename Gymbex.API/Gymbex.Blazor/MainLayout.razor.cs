using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Gymbex.Blazor
{
    public partial class MainLayout
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        private void ShowActivities()
        {
            NavigationManager.NavigateTo("/activities");
        }

        private void ShowTickets()
        {
            NavigationManager.NavigateTo("/tickets");
        }
    }
}
