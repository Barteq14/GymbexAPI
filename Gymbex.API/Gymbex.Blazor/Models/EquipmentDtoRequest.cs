using Gymbex.Blazor.Enums;

namespace Gymbex.Blazor.Models
{
    public class EquipmentDtoRequest
    {
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public EquipmentState EquipmentState { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryEquipmentId { get; set; }


        public EquipmentDtoRequest()
        {
            
        }

    }
}
