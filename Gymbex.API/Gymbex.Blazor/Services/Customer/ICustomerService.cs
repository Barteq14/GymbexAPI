using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Customer
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerDtoAsync(Guid id);
        Task<List<CustomerDto>> GetCustomersAsync();
        Task<List<CustomerDto>> GetInstructorsAsync();
        Task<UpdateResultCustomer> UpdateCustomerDtoAsync(UpdateCustomer model);
        Task ChangeRoleAsync(Guid id, string Role);
        Task DeleteUserAsync(Guid customerId);

        //tickets   
        Task<List<TicketDto>> GetTickets();
        Task<ResponseModel> ChooseTicket(ChooseTicketRequest command);
        Task RemoveTicket(Guid customerId);


        //reservations
        Task<List<ReservationDto>> GetCustomerReservations(Guid customerId);
    }
}
