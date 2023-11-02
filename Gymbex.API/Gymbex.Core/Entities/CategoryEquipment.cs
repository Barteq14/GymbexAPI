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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalQuantity { get; set; }

        public IEnumerable<Equipment> Equipments { get; private set; } = _equipments;

        public CategoryEquipment(Guid id, string name, int totalQuantity)
        {
            Id = id;
            Name = name;
            TotalQuantity = totalQuantity;
        }

        public CategoryEquipment Create(Guid id, string name, int totalQuantity)
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
