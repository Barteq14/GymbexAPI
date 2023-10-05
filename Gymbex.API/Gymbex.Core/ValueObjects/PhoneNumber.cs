using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record PhoneNumber
    {
        private readonly Regex PhoneNumberRegex = new Regex(@"\\(?([0-9]{3})\\)?([ .-]?)([0-9]{3})\\2([0-9]{4})/", RegexOptions.Compiled);
        public string Value { get; set; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidPhoneNumberException();
            }

            if (!PhoneNumberRegex.IsMatch(value))
            {
                throw new InvalidPhoneNumberException(value);
            }
            Value = value;
        }

        public static implicit operator PhoneNumber(string value) => new PhoneNumber(value);
        public static implicit operator string(PhoneNumber value) => value.Value;
    }
}
