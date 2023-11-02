using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentQuantity
    {
        public int Value { get; }

        public EquipmentQuantity(int value)
        {
            Value = value;
        }

        public static implicit operator EquipmentQuantity(int value) => new EquipmentQuantity(value);
        public static implicit operator int(EquipmentQuantity value) => value.Value;
    }
}
