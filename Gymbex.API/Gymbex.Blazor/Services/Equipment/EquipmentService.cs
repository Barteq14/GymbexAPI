using Gymbex.Blazor.Models;
using Gymbex.Blazor.Utils;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services.Equipment
{
    public sealed class EquipmentService : IEquipmentService
    {
        private readonly HttpClient _httpClient;

        public EquipmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StateObject<List<EquipmentDto>>> GetEquipments()
        {
            var state = new StateObject<List<EquipmentDto>>();
            var response = await _httpClient.GetAsync($"{Const.API_URL}api/equipment");
            if (response.IsSuccessStatusCode)
            {
                var equipmentResponse = await response.Content.ReadFromJsonAsync<List<EquipmentDto>>();

                state.IsSuccess = true;
                state.Message = "Poprawnie pobrano dane.";
                state.StateModel = equipmentResponse;
            }

            return state;
        }

        public async Task<ResponseModel> UpdateEquipment(EquipmentDtoRequest equipment)
        {
            var result = new ResponseModel();
            var response = await _httpClient.PutAsJsonAsync($"{Const.API_URL}api/equipment/edit-equipment/{equipment.EquipmentId}", equipment);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
            }

            return result;
        }
    }
}
