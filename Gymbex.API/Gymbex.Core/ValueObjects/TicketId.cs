﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.ValueObjects
{
    public sealed record TicketId
    {
        public Guid? Value { get; }
        public TicketId(Guid? value)
        {
            if (value.HasValue)
            {
                Value = value.Value;
            }
        }

        public static implicit operator TicketId(Guid? value) => new(value);
        public static implicit operator Guid?(TicketId value) => value is not null ? value.Value : null;
    }
}
