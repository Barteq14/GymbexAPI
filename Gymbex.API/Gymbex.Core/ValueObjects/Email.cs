using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record Email
    {
        private readonly Regex EmailRegex = new Regex(@"^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", RegexOptions.Compiled);
        public string Value { get; set; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidEmailException();
            }

            if (value.Length > 100)
            {
                throw new InvalidEmailException(value);
            }

            value = value.ToLowerInvariant();

            if (!EmailRegex.IsMatch(value))
            {
                throw new InvalidEmailException(value);
            }
            Value = value;
        }

        public static implicit operator Email(string email) => new Email(email);
        public static implicit operator string(Email email) => email.Value;
    }
}
