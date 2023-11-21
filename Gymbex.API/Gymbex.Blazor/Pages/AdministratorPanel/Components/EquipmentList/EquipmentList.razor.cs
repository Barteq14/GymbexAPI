using Gymbex.Blazor.Components;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services.Customer;
using Gymbex.Blazor.Services.Equipment;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages.AdministratorPanel.Components.EquipmentList
{
    using EquipmentStateDictionaryAlias = Dictionary<int, string>;
    public partial class EquipmentList
    {
        [Inject] public IEquipmentService EquipmentService { get; set; }
        [Parameter] public List<EquipmentDto> Items { get; set; }
        public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();
        public List<CategoryEquipmentDto> Categories { get; set; }
        EquipmentDto ModelToUpdate { get; set; } = new EquipmentDto();
        EquipmentDto ModelToDelete { get; set; } = new EquipmentDto();
        public ModalBlazor ModalBlazor { get; set; } = new ModalBlazor();
        private string ModalClass = "modal";
        private string ModalId = "equipment-modal";

        public ModalBlazor AlertModal { get; set; } = new ModalBlazor();
        private string ModalAlertClass = "modal";
        private string ModalAlertId = "equipment-modal-alert-id";

        public EquipmentStateDictionaryAlias EquipmentStatesList { get; set; } = new EquipmentStateDictionaryAlias
        {
            { 0, "Stan zły" },
            { 1, "Stan dobry" }
        };

        protected override async Task OnParametersSetAsync()
        {
          
            var stateEquipmentResult = await EquipmentService.GetEquipments();
            if (stateEquipmentResult.IsSuccess)
            {
                Equipments = stateEquipmentResult.StateModel;
            }

            //pobranie wszystkich kategorii sprzętu
        }

        private async Task OpenModal(EquipmentDto equipment)
        {
            await JSRuntime.InvokeVoidAsync("showModal", ModalId);

            ModelToUpdate = equipment;
        }

        public void SaveHandler()
        {

        }

        private async Task OpenAlertModal(EquipmentDto equipment)
        {
            await JSRuntime.InvokeVoidAsync("showModal", ModalAlertId);
            ModelToDelete = equipment;
        }
        private async Task DeleteUser()
        {
           /* await CustomerService.DeleteUserAsync(ModelToDelete.Id);
            NavigationManager.NavigateTo("/adminPanel", true);*/
        }
    }
}
