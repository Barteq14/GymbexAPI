using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Reservation
{
    public interface IReservationService
    {
        Task<List<ReservationDto>> GetAllReservationsForAdmin();
    }
}
