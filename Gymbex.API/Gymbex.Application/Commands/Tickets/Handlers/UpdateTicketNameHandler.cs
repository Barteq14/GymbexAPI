using Gymbex.Application.Abstractions;
using Gymbex.Core.Repositories;
using Gymbex.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Tickets.Handlers
{
    public sealed class UpdateTicketNameHandler(ITicketRepository ticketRepository) : ICommandHandler<UpdateTicketName>
    {
        public async Task HandlerExecuteAsync(UpdateTicketName command)
        {
            var ticket = await ticketRepository.GetAsync(command.TicketId);
            if(ticket is null)
            {
                throw new TicketNotFoundException(command.TicketId);
            }

            ticket.ChangeTicketKind(command.TicketKindEnum);
            await ticketRepository.UpdateAsync(ticket);
        }
    }
}
