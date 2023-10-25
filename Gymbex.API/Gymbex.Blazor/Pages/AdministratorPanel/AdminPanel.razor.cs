using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages.AdministratorPanel
{
    public partial class AdminPanel
    {
        [Inject] public NavigationManager NavigationManager{ get; set; }
        [Inject] public ICustomerService CustomerService{ get; set; }
        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

        protected override async Task OnParametersSetAsync()
        {
            Customers = await CustomerService.GetCustomersAsync();
        }

        public bool ShowCustomers { get; set; }

        private void Go()
        {
            ShowCustomers = true;
            StateHasChanged();
        }
    }
}
