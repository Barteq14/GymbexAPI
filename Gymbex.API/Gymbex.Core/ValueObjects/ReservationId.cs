using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects
{
    public sealed record ReservationId
    {
        public Guid Value { get; }

        public ReservationId(Guid value)
        {
            Value = value;
        }

        public static implicit operator ReservationId(Guid id) => new ReservationId(id);
        public static implicit operator Guid(ReservationId id) => id.Value;
    }
}
