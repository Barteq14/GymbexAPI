using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerDtoAsync(Guid id);
        Task<UpdateResultCustomer> UpdateCustomerDtoAsync(UpdateCustomer model);

        //tickets   
        Task<List<Ticket>> GetTickets();
        Task<ResponseModel> ChooseTicket(ChooseTicketRequest command);
        Task RemoveTicket(Guid customerId);
    }
}
