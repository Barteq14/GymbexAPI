using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class EndTicketDateIsNullException : CustomException
    {
        public EndTicketDateIsNullException() 
            : base($"End date for ticket was null.")
        {
        }
    }
}
