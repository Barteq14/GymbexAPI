using Gymbex.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentStateEnum
    {
        public EquipmentState Value { get; }

        public EquipmentStateEnum(EquipmentState state)
        {
            Value = state;
        }

        public static implicit operator EquipmentStateEnum(EquipmentState value) => new EquipmentStateEnum(value);
        public static implicit operator EquipmentState(EquipmentStateEnum value) => value.Value;
    }
}
