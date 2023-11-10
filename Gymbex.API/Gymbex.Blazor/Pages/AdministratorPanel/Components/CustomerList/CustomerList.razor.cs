using Gymbex.Blazor.Components;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services.Customer;
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
        CustomerDto ModelToDelete { get; set; } = new CustomerDto();
        public ModalBlazor ModalBlazor { get; set; } = new ModalBlazor();
        private string ModalClass = "modal";
        private string ModalId = "account-modal";

        public ModalBlazor AlertModal { get; set; } = new ModalBlazor();
        private string ModalAlertClass = "modal";
        private string ModalAlertId = "modal-alert-id";

        private string selectedOption;
        public List<string> Roles = new List<string> { "User", "Admin", "Instructor" };
        public BlazorAlert AlertComponent;

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

        private async Task OpenAlertModal(CustomerDto customer)
        {
            await JSRuntime.InvokeVoidAsync("showModal", ModalAlertId);
            ModelToDelete = customer;
        }
        private async Task DeleteUser()
        {
            await CustomerService.DeleteUserAsync(ModelToDelete.Id);
            NavigationManager.NavigateTo("/adminPanel", true);
        }
    }
}
