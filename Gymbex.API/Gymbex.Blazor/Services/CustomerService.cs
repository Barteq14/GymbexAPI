using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        private const string API = "https://localhost:7291/";
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomerDto> GetCustomerDtoAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{API}api/customer/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CustomerDto>();
                return result;
            }

            return null;
        }
    }
}
