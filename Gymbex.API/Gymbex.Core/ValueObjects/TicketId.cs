using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects
{
    public sealed record TicketId
    {
        public Guid Value { get; private set; }
        public TicketId(Guid value)
        {
            Value = value;
        }

        public static implicit operator TicketId(Guid value) => new TicketId(value);
        public static implicit operator Guid(TicketId value) => value.Value;
    }
}
