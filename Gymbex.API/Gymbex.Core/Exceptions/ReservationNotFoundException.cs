using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class ReservationNotFoundException : CustomException
    {
        public ReservationNotFoundException(Guid id)
            : base($"Reservation with id: {id} was not found.")
        {
        }
    }
}
