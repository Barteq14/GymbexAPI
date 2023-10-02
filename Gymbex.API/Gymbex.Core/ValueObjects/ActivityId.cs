using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects
{
    public sealed record ActivityId
    {
        public Guid Id { get; }

        public ActivityId(Guid id)
        {
            Id = id;
        }

        public static implicit operator ActivityId(Guid id) => new ActivityId(id);
        public static implicit operator Guid(ActivityId id) => id.Id;
    }
}
