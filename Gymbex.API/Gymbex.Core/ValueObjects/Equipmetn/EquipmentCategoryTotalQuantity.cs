using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentCategoryTotalQuantity
    {
        public int Value { get;}

        public EquipmentCategoryTotalQuantity(int value)
        {
            Value = value;
        }

        public static implicit operator EquipmentCategoryTotalQuantity(int value) => new EquipmentCategoryTotalQuantity(value);
        public static implicit operator int(EquipmentCategoryTotalQuantity value) => value.Value;
    }
}
