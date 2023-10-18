using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerDtoAsync(Guid id);
    }
}
