using Gymbex.Blazor.Models;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;

        private const string API = "https://localhost:7291/";
        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Ticket> GetTicketAsync(Guid ticketId)
        {
            var response = await _httpClient.GetAsync($"{API}api/ticket/{ticketId}");
            var ticket = new Ticket();
            if (response.IsSuccessStatusCode)
            {
                ticket = await response.Content.ReadFromJsonAsync<Ticket>();
            }

            return ticket;
        }
    }
}
