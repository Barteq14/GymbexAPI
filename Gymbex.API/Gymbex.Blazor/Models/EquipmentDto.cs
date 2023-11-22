using Gymbex.Blazor.Enums;
using System.Text.Json.Serialization;

namespace Gymbex.Blazor.Models
{
    public sealed class EquipmentDto
    {
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public string EquipmentState { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryEquipmentId { get; set; }
        public string CategoryName { get; set; }

        public EquipmentDto(Guid equipmentId, string equipmentName, string equipmentDescription, string equipmentState, int quantity, Guid categoryEquipmentId, string categoryName)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            EquipmentDescription = equipmentDescription;
            EquipmentState = equipmentState;
            Quantity = quantity;
            CategoryEquipmentId = categoryEquipmentId;
            CategoryName = categoryName;
        }

        public EquipmentDto()
        {
            
        }
    }
}
