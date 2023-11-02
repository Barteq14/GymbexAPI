using Gymbex.Core.ValueObjects.Equipmetn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Entities
{
    public sealed class CategoryEquipment
    {
        private static readonly HashSet<Equipment> _equipments = new();
        public EquipmentCategoryId Id { get; set; }
        public EquipmentCategoryName Name { get; set; }
        public EquipmentCategoryTotalQuantity TotalQuantity { get; set; }

        public IEnumerable<Equipment> Equipments { get; private set; } = _equipments;

        public CategoryEquipment(EquipmentCategoryId id, EquipmentCategoryName name, EquipmentCategoryTotalQuantity totalQuantity)
        {
            Id = id;
            Name = name;
            TotalQuantity = totalQuantity;
        }

        public CategoryEquipment Create(EquipmentCategoryId id, EquipmentCategoryName name, EquipmentCategoryTotalQuantity totalQuantity)
            => new CategoryEquipment(Id, name, totalQuantity);

        public void AddEquipment(Equipment equipment)
        {
            _equipments.Add(equipment);
        }

        public void RemoveEquipment(Equipment equipment)
        {
            _equipments.Remove(equipment);
        }
    }
}
