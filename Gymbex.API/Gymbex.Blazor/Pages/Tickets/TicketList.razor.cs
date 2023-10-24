using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;

namespace Gymbex.Blazor.Pages.Tickets
{
    public partial class TicketList
    {
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public ICustomerService CustomerService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public List<Ticket> TicketsList { get; set; } = new();
        public string Content { get; set; } = string.Empty;
        public bool IsError { get; set; } = false;

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
            var token = await LocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();

            var jwt = new JwtSecurityToken(token);

            var uniqueName = jwt.Claims.FirstOrDefault(c => c.Type == "unique_name").Value;

            var id = Guid.Parse(uniqueName);

            var command = new ChooseTicketRequest { CustomerId = id, TicketId = ticketId};

            var response = await CustomerService.ChooseTicket(command);

            if (response.IsSuccess)
            {
                IsError = false;
                Content = "Właśnie wybrałeś swój karnet.";
            }
            else
            {
                IsError = true;
                Content = response.Error;
            }
        }
    }
}
