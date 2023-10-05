using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects
{
    public sealed record CustomerId
    {
        public Guid Id { get; private set; }

        public CustomerId(Guid id)
        {
            Id = id;
        }

        public static implicit operator CustomerId(Guid id) => new CustomerId(id);
        public static implicit operator Guid(CustomerId id) => id.Id;
    }
}
