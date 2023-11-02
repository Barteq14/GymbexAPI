using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface IReservationService
    {
        Task<List<ReservationDto>> GetAllReservationsForAdmin();
    }
}
