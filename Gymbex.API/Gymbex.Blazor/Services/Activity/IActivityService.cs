using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Activity
{
    public interface IActivityService
    {
        Task<ReservationActivityResponse> RegisterOnActivity(ReservationActivityRequest command, Guid activityId);
        Task<List<ActivityDto>> GetActivitiesAsync();
    }
}
