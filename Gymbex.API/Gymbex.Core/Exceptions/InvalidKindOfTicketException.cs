using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class InvalidKindOfTicketException : CustomException
    {
        public InvalidKindOfTicketException(int kind) 
            : base($"This int value: {kind} is incorrect for TicketKindEnum.")
        {
        }
    }
}
