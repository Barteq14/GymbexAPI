using Gymbex.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentName
    {
        public string Value { get; }

        public EquipmentName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidEquipmentNameException();
            }

            Value = value;
        }

        public static implicit operator EquipmentName(string value) => new EquipmentName(value);
        public static implicit operator string(EquipmentName value) => value.Value;
    }
}
