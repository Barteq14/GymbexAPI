using Gymbex.Blazor.Models;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services
{
    public sealed class ActivityService : IActivityService
    {
        private readonly HttpClient _httpClient;

        private const string API = "https://localhost:7291/";
        public ActivityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReservationActivityResponse> RegisterOnActivity(ReservationActivityRequest command, Guid activityId)
        {
            var response = await _httpClient.PostAsJsonAsync($"{API}api/activity/registration-activity/{activityId}",command);
            ReservationActivityResponse reservationActivityResponse = new ReservationActivityResponse();

            if (response.IsSuccessStatusCode)
            {
                var reservationResult = await response.Content.ReadFromJsonAsync<ReservationActivityResponse>();

                reservationActivityResponse = reservationResult;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var reservationResult = await response.Content.ReadFromJsonAsync<ReservationActivityResponse>();

                reservationActivityResponse.IsSuccess = false;
                reservationActivityResponse.Error = reservationResult.Error;
            }
            
            return reservationActivityResponse;
        }
    }
}
