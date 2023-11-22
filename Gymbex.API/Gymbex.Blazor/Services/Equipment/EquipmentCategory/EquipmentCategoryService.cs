using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Utils;
using System.Net.Http.Json;

namespace Gymbex.Blazor.Services.Equipment.EquipmentCategory
{
    using StateObjectResult = StateObject<List<CategoryEquipmentDto>>;
    public class EquipmentCategoryService(HttpClient httpClient) : IEquipmentCategoryService
    {
        public async Task<StateObjectResult> GetAllAsync()
        {
            var stateObject = new StateObjectResult();
            var response = await httpClient.GetAsync($"{Const.API_URL}api/equipmentCategories");
            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadFromJsonAsync<List<CategoryEquipmentDto>>();
                stateObject.IsSuccess = true;
                stateObject.StateModel = results;
            }

            return stateObject;
        }
    }
}
