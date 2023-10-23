using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class TikcetNotFoundException : CustomException
    {
        public TikcetNotFoundException(Guid id) 
            : base($"Ticket with id: {id} was not found.")
        {
        }
    }
}
