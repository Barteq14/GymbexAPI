using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class CustomerAlreadyHasTicketException : CustomException
    {
        public CustomerAlreadyHasTicketException() 
            : base($"Customer already has a ticket.")
        {
        }
    }
}
