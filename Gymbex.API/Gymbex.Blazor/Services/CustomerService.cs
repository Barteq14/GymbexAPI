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

        public async Task<UpdateResultCustomer> UpdateCustomerDtoAsync(UpdateCustomer model)
        {
            UpdateResultCustomer updateResultCustomer = new UpdateResultCustomer();
            var response = await _httpClient.PutAsJsonAsync($"{API}api/customer", model);

            if (response.IsSuccessStatusCode)
            {
                updateResultCustomer.IsSuccess = true;
            }

            var updateResult = await response.Content.ReadFromJsonAsync<UpdateResultCustomer>();
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                updateResultCustomer.IsSuccess = false;
                updateResultCustomer.Error = updateResult.Error;
            }

            return updateResultCustomer;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            var response = await _httpClient.GetAsync($"{API}api/ticket");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<Ticket>>();
                return result;
            }

            return null;
        }
    }
}
