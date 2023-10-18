using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages.Account
{
    public partial class MyAccount
    {
        [Parameter] public Guid CustomerId { get; set; }
        [Inject] public ICustomerService CustomerService { get; set; }
        public CustomerDto CustomerDto { get; set; } = new CustomerDto();


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
        }
    }
}
