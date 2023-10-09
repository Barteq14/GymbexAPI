using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Exceptions
{
    public sealed class InvalidTicketDatesException : CustomException
    {
        public InvalidTicketDatesException() 
            : base($"Dates are invalid.")
        {
        }
    }
}
