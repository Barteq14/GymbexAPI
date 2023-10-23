using Gymbex.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Customers
{
    public sealed record ChooseTicket(Guid TicketId, Guid CustomerId) : ICommand;
}
