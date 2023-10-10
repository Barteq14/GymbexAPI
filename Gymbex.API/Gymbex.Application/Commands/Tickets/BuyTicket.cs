using Gymbex.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Tickets
{
    public sealed record BuyTicket(Guid TicketId, Guid CustomerId) : ICommand;
}
