using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record Fullname
    {
        public string Value { get; set; }

        public Fullname(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                throw new InvalidFullnameException();
            }
            Value = fullname;
        }

        public static implicit operator Fullname(string fullname) => new Fullname(fullname);
        public static implicit operator string(Fullname fullname) => fullname.Value;
    }
}
