using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;

namespace Gymbex.Application.Commands.Tickets.Handlers
{
    internal sealed class DeleteTicketHandler : ICommandHandler<DeleteTicket>
    {
        private readonly ITicketRepository _ticketRepository;

        public DeleteTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task HandlerExecuteAsync(DeleteTicket command)
        {
            var ticket = await _ticketRepository.GetAsync(command.TicketId);
            if (ticket is null)
            {
                throw new TicketNotFoundException(command.TicketId);
            }

            await _ticketRepository.DeleteAsync(ticket);
        }
    }
}
