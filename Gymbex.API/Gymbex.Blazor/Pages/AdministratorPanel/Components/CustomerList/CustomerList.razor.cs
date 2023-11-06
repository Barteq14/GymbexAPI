using Gymbex.Blazor.Components;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages.AdministratorPanel.Components.CustomerList
{
    public partial class CustomerList
    {
        [Parameter] public List<CustomerDto> Items{ get; set; }
        [Inject] ICustomerService CustomerService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        CustomerDto ModelToUpdate { get; set; } = new CustomerDto();
        public ModalBlazor ModalBlazor { get; set; } = new ModalBlazor();
        private string ModalClass = "modal";
        private string ModalId = "account-modal";
        private string selectedOption;
        public List<string> Roles = new List<string> { "User", "Admin", "Instructor" };

        private async Task OpenModal(CustomerDto customer)
        {
            await JSRuntime.InvokeVoidAsync("showModal", ModalId);

            ModelToUpdate = customer;
        }

        private async Task SaveHandler()
        {
            await CustomerService.ChangeRoleAsync(ModelToUpdate.Id, ModelToUpdate.Role);
            NavigationManager.NavigateTo("/adminPanel", true);
        }
    }
}
