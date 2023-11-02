using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentId
    {
        public Guid Value { get; }
        public EquipmentId(Guid value)
        {
            Value = value;
        }

        public static implicit operator EquipmentId(Guid id) => new EquipmentId(id);
        public static implicit operator Guid(EquipmentId id) => id.Value;
    }
}
