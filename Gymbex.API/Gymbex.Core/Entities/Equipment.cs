using Gymbex.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Entities
{
    public class Equipment
    {
        Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EquipmentState EquipmentState { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryEquipmentId { get; set; }
        public CategoryEquipment CategoryEquipment { get; set; }


        public Equipment(Guid id, string name, string description, EquipmentState equipmentState, int quantity, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            EquipmentState = equipmentState;
            Quantity = quantity;
            CategoryEquipmentId = categoryId;
        }

        public Equipment Create(Guid id, string name, string description, EquipmentState equipmentState, int quantity, Guid categoryId)
                => new Equipment(id, name, description, equipmentState, quantity, categoryId);

    }
}
