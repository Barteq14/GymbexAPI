using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Exceptions
{
    public sealed class ReservationAlreadyExistsException : CustomException
    {
        public ReservationAlreadyExistsException(ActivityId id) 
            : base($"Reservation already exist for activity with id: {id}")
        {
        }
    }
}
