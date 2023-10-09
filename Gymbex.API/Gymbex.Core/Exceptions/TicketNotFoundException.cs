using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Exceptions
{
    public sealed class TicketNotFoundException : CustomException
    {
        public TicketNotFoundException(TicketId id) 
            : base($"Ticket with id:{id} was not found.")
        {
        }
    }
}
