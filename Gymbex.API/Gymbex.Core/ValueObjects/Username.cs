using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record Username
    {
        public string Value { get; private set; }

        public Username(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidUsernameException();
            }
            Value = value;
        }

        public static implicit operator Username(string value) => new Username(value);
        public static implicit operator string(Username value) => value.Value;
    }
}
