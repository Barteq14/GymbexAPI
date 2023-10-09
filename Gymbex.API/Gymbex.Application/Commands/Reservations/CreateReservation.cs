using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Reservations
{
    public sealed record CreateReservation(Guid ReservationId, DateTime ReservationDate, Guid CustomerId,
        Guid ActivityId) : ICommand;
}
