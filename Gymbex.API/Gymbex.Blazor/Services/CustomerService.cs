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

        public async Task<ResponseModel> ChooseTicket(ChooseTicketRequest command)
        {
            var response = await _httpClient.PostAsJsonAsync($"{API}api/customer/choose-ticket", command);
            var responseModel = new ResponseModel();

            if (!response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseModel>();

                responseModel.IsSuccess = response.IsSuccessStatusCode;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    responseModel.IsSuccess = false;
                    responseModel.Error = result.Error;
                }
            }
            else
            {
                responseModel.IsSuccess = true;
            }

            return responseModel;
        }

        public async Task RemoveTicket(Guid customerId)
        {
            var removeTicketModel = new RemoveTicket();
            removeTicketModel.CustomerId = customerId;

            var response = await _httpClient.PutAsJsonAsync($"{API}api/customer/remove-ticket", removeTicketModel);
            if (response.IsSuccessStatusCode)
            {

            }
            else
            {

            }
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync($"{API}api/customer");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();

                return result;
            }

            return new List<CustomerDto>();
        }

        public async Task<List<CustomerDto>> GetInstructorsAsync()
        {
            var response = await _httpClient.GetAsync($"{API}api/customer/instructors");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();

                return result;
            }

            return new List<CustomerDto>();
        }

        public async Task<List<ReservationDto>> GetCustomerReservations(Guid customerId)
        {
            var response = await _httpClient.GetAsync($"{API}api/customer/customer-reservations/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<ReservationDto>>();

                return result;
            }

            return new List<ReservationDto>();
        }
    }
}
