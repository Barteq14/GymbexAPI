using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class TicketAlreadyExistsException : CustomException
    {
        public TicketAlreadyExistsException(string username) 
            : base($"Ticket already exists for this customer: {username}")
        {
        }
    }
}
