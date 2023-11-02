using Gymbex.Core.Enums;
using Gymbex.Core.ValueObjects.Equipmetn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Entities
{
    public class Equipment
    {
        public EquipmentId Id { get; set; }
        public EquipmentName Name { get; set; }
        public EquipmentDescription Description { get; set; }
        public EquipmentStateEnum EquipmentState { get; set; }
        public EquipmentQuantity Quantity { get; set; }
        public Guid CategoryEquipmentId { get; set; }
        public CategoryEquipment CategoryEquipment { get; set; }


        public Equipment(EquipmentId id, EquipmentName name, EquipmentDescription description, EquipmentStateEnum equipmentState, int quantity, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            EquipmentState = equipmentState;
            Quantity = quantity;
            CategoryEquipmentId = categoryId;
        }

        public Equipment Create(EquipmentId id, EquipmentName name, EquipmentDescription description, EquipmentStateEnum equipmentState, int quantity, Guid categoryId)
                => new Equipment(id, name, description, equipmentState, quantity, categoryId);

    }
}
