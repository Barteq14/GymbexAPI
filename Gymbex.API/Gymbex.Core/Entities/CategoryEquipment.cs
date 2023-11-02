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
        public CategoryEquipmentId Id { get; private set; }
        public EquipmentCategoryName Name { get; private set; }

        public IEnumerable<Equipment> Equipments { get; private set; } = _equipments;

        public CategoryEquipment(CategoryEquipmentId id, EquipmentCategoryName name) {  
            Id = id;
            Name = name;
        }

        public static CategoryEquipment Create(CategoryEquipmentId id, EquipmentCategoryName name)
            => new CategoryEquipment(id, name);

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
