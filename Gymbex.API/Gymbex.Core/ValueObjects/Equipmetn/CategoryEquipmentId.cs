using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record CategoryEquipmentId
    {
        public Guid Value { get; }

        public CategoryEquipmentId(Guid value)
        {
            Value = value;
        }

        public static implicit operator CategoryEquipmentId(Guid id) => new CategoryEquipmentId(id);
        public static implicit operator Guid(CategoryEquipmentId id) => id.Value;
    }
}
