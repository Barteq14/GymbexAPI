using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record Date
    {
        public DateTime Value { get;}

        public Date(DateTime value)
        {
            Value = value.SetKindUtc();
        }

        public static implicit operator Date(DateTime date) => new Date(date);
        public static implicit operator DateTime(Date date) => date.Value;
    }
}
