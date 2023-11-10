using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Ticket
{
    public interface ITicketService
    {
        //metoda do pobrania ticketu
        Task<TicketDto> GetTicketAsync(Guid ticketId);
        Task<List<TicketDto>> GetTicketsAsync();
        Task RemoveTicketAsync(Guid customerId);
    }
}
