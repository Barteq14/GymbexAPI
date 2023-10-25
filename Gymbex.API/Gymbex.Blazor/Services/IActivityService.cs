using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface IActivityService
    {
        Task<ReservationActivityResponse> RegisterOnActivity(ReservationActivityRequest command, Guid activityId);
        Task<List<ActivityDto>> GetActivitiesAsync();
    }
}
