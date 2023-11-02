using Gymbex.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentDescription
    {
        public string Value { get; }

        public EquipmentDescription(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidEquipmentDescriptionException();
            }

            Value = value;
        }

        public static implicit operator EquipmentDescription(string value) => new EquipmentDescription(value);
        public static implicit operator string(EquipmentDescription value) => value.Value;
    }
}
