using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentCategoryId
    {
        public Guid Value { get; }

        public EquipmentCategoryId(Guid value)
        {
            Value = value;
        }

        public static implicit operator EquipmentCategoryId(Guid id) => new EquipmentCategoryId(id);
        public static implicit operator Guid(EquipmentCategoryId id) => id.Value;
    }
}
