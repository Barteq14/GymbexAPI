using Gymbex.Blazor.Components;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services.Customer;
using Gymbex.Blazor.Services.Equipment;
using Gymbex.Blazor.Services.Equipment.EquipmentCategory;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages.AdministratorPanel.Components.EquipmentList
{
    using EquipmentStateDictionaryAlias = List<Gymbex.Blazor.Enums.EquipmentState>;
    using StateObjectResult = StateObject<List<CategoryEquipmentDto>>;
    public partial class EquipmentList
    {
        [Inject] public IEquipmentService EquipmentService { get; set; }
        [Inject] public IEquipmentCategoryService EquipmentCategoryService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }   
        [Parameter] public List<EquipmentDto> Items { get; set; }
        public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();
        public StateObjectResult Categories { get; set; }
        EquipmentDto Model { get; set; }
        EquipmentDtoRequest ModelToUpdate { get; set; } = new EquipmentDtoRequest();
        EquipmentDto ModelToDelete { get; set; }
        public ModalBlazor ModalBlazor { get; set; } = new ModalBlazor();
        private string ModalClass = "modal";
        private string ModalId = "equipment-modal";

        public ModalBlazor AlertModal { get; set; } = new ModalBlazor();
        private string ModalAlertClass = "modal";
        private string ModalAlertId = "equipment-modal-alert-id";

        public EquipmentStateDictionaryAlias EquipmentStatesList { get; set; } = new EquipmentStateDictionaryAlias()
        {
            Enums.EquipmentState.BadState,
            Enums.EquipmentState.GoodState
        };

        protected override async Task OnParametersSetAsync()
        {
          
           /* var stateEquipmentResult = await EquipmentService.GetEquipments();
            if (stateEquipmentResult.IsSuccess)
            {
                Equipments = stateEquipmentResult.StateModel;
            }*/

            //pobranie wszystkich kategorii sprzętu
            Categories = await EquipmentCategoryService.GetAllAsync();
        }

        private async Task OpenModal(EquipmentDto equipment)
        {
            ModelToUpdate = new EquipmentDtoRequest()
            {
                EquipmentId = equipment.EquipmentId,
                EquipmentName = equipment.EquipmentName,
                EquipmentDescription = equipment.EquipmentDescription,
                EquipmentState = equipment.EquipmentState.Equals("Stan zły") ? Enums.EquipmentState.BadState : Enums.EquipmentState.GoodState,
                Quantity = equipment.Quantity
            };
                
            var category = Categories.StateModel.FirstOrDefault(x => x.Name.Equals(equipment.CategoryName));

            ModelToUpdate.CategoryEquipmentId = category.Id;

            await JSRuntime.InvokeVoidAsync("showModal", ModalId);
        }

        public async void SaveHandler()
        {
            var result = await EquipmentService.UpdateEquipment(ModelToUpdate);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/adminPanel", true);
            }
        }

        private async Task OpenAlertModal(EquipmentDto equipment)
        {
            var category = Categories.StateModel.FirstOrDefault(x => x.Name.Equals(equipment.CategoryName));
            ModelToDelete = new EquipmentDto(
                equipment.EquipmentId,
                equipment.EquipmentName,
                equipment.EquipmentDescription,
                equipment.EquipmentState,
                equipment.Quantity,
                category.Id,
                equipment.CategoryName);

            await JSRuntime.InvokeVoidAsync("showModal", ModalAlertId);
        }
        private async Task DeleteUser()
        {
           /* await CustomerService.DeleteUserAsync(ModelToDelete.Id);
            NavigationManager.NavigateTo("/adminPanel", true);*/
        }
    }
}
