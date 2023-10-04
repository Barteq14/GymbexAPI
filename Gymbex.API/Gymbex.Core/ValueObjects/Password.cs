using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record Password
    {
        public string Value { get; private set; }

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidPasswordException();
            }

            if (value.Length < 8)
            {
                throw new InvalidPasswordException(value);
            }
            Value = value;
        }

        public static implicit operator Password(string value) => new Password(value);
        public static implicit operator string(Password value) => value.Value;
    }
}
