using Gymbex.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Tickets
{
    public sealed record CreateTicket(Guid ticketId, int ticketKind, string KindDescription) : ICommand;
}
