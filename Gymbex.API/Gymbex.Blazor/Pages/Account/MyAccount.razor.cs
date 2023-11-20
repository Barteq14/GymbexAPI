using Gymbex.Blazor.Components;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services.Customer;
using Gymbex.Blazor.Services.Ticket;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages.Account
{
    public partial class MyAccount
    {
        [Parameter] public Guid CustomerId { get; set; }
        [Inject] public ICustomerService CustomerService { get; set; }
        [Inject] public ITicketService TicketService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public CustomerDto CustomerDto { get; set; }
        public UpdateCustomer ModelToUpdate { get; set; } = new UpdateCustomer();
        private bool ShowErrors;
        private string Error = "";
        private string ModalId = "account-modal";
        private string ModalClass = "modal";
        private string TicketName = string.Empty;
        public ModalBlazor ModalBlazor { get; set; } = new ModalBlazor();

        protected override async Task OnInitializedAsync()
        {
            var userDto = await CustomerService.GetCustomerDtoAsync(CustomerId);

            if(userDto is null)
            {
                throw new Exception("User is null");
            }
            else
            {
                CustomerDto = userDto;
            }
            
            ModelToUpdate.Fullname = CustomerDto.FullName;
            ModelToUpdate.Username = CustomerDto.Username;
            ModelToUpdate.Phone = CustomerDto.PhoneNumber;
            ModelToUpdate.CustomerId = CustomerId;

            TicketName = CustomerDto.TicketName;
        }

        private async Task ShowModal()
        {
            await JSRuntime.InvokeVoidAsync("showModal", ModalId);
        }

        private async Task SaveHandler()
        {
            var result = await CustomerService.UpdateCustomerDtoAsync(ModelToUpdate);
            if (!result.IsSuccess)
            {
                Error = result.Error;
            }
            await JSRuntime.InvokeVoidAsync("closeModal", ModalId);
            StateHasChanged();
            NavigationManager.NavigateTo($"/myAccount/{CustomerId}",true);
        }

        private async Task RemoveTicket()
        {
            await CustomerService.RemoveTicket(CustomerId);
            NavigationManager.NavigateTo($"/myAccount/{CustomerId}",true);
        }
    }
}
