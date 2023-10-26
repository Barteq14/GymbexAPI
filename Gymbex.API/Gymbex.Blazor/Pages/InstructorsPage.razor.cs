using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages
{
    public partial class InstructorsPage
    {
        [Inject] public ICustomerService CustomerService { get; set; }
        public List<CustomerDto> Instructors { get; set; } = new List<CustomerDto>();

        protected override async Task OnInitializedAsync()
        {
            Instructors = await CustomerService.GetInstructorsAsync();
        }
    }
}
