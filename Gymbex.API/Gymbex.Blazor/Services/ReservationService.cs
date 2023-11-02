using Gymbex.Blazor.Models;
using Gymbex.Blazor.Utils;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _httpClient;

        public ReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReservationDto>> GetAllReservationsForAdmin()
        {
            var response = await _httpClient.GetAsync($"{Const.API_URL}api/reservation");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<ReservationDto>>();
                return result;
            }

            return null;
        }
    }
}
