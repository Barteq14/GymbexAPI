using Gymbex.Blazor.Models;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;

        private const string API = "https://localhost:7291/";
        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TicketDto> GetTicketAsync(Guid ticketId)
        {
            var response = await _httpClient.GetAsync($"{API}api/ticket/{ticketId}");
            var ticket = new TicketDto();
            if (response.IsSuccessStatusCode)
            {
                ticket = await response.Content.ReadFromJsonAsync<TicketDto>();
            }

            return ticket;
        }

        public Task RemoveTicketAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TicketDto>> GetTicketsAsync()
        {
            var response = await _httpClient.GetAsync($"{API}api/ticket");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<TicketDto>>();

                return result;
            }

            return new List<TicketDto>();
        }
    }
}
