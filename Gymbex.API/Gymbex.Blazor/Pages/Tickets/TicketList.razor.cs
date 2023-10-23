using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages.Tickets
{
    public partial class TicketList
    {
        [Inject] public ICustomerService CustomerService { get; set; }
        public List<Ticket> TicketsList { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetTicketList();
        }

        private async Task GetTicketList()
        {
            TicketsList = await CustomerService.GetTickets();
        }

        private async Task ChooseTicket(Guid ticketId)
        {

        }
    }
}
