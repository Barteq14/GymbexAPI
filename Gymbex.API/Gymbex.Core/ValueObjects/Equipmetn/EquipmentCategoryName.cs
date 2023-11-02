using Gymbex.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects.Equipmetn
{
    public sealed record EquipmentCategoryName
    {
        public string Value { get; }

        public EquipmentCategoryName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidEquipmentCategoryNameException();
            }

            Value = value;
        }

        public static implicit operator EquipmentCategoryName(string value) => new EquipmentCategoryName(value);
        public static implicit operator string(EquipmentCategoryName value) => value.Value;
    }
}
