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
        public EquipmentId Id { get; private set; }
        public EquipmentName Name { get; private set; }
        public EquipmentDescription Description { get; private set; }
        public EquipmentStateEnum EquipmentState { get; private set; }
        public EquipmentQuantity Quantity { get; private set; }
        public CategoryEquipmentId CategoryEquipmentId { get; private set; }
        public CategoryEquipment CategoryEquipment { get; private set; }


        public Equipment(EquipmentId id, EquipmentName name, EquipmentDescription description, EquipmentStateEnum equipmentState, EquipmentQuantity quantity, CategoryEquipmentId categoryEquipmentId)
        {
            Id = id;
            Name = name;
            Description = description;
            EquipmentState = equipmentState;
            Quantity = quantity;
            CategoryEquipmentId = categoryEquipmentId;
        }

        public static Equipment Create(EquipmentId id, EquipmentName name, EquipmentDescription description, EquipmentStateEnum equipmentState, EquipmentQuantity quantity, CategoryEquipmentId categoryEquipmentId)
                => new Equipment(id, name, description, equipmentState, quantity, categoryEquipmentId);

    }
}
