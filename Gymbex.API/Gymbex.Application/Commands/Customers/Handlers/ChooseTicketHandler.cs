using Gymbex.Application.Abstractions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class ChooseTicketHandler : ICommandHandler<ChooseTicket>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITicketRepository _ticketRepository;

        public ChooseTicketHandler(ICustomerRepository customerRepository, ITicketRepository ticketRepository)
        {
            _customerRepository = customerRepository;
            _ticketRepository = ticketRepository;
        }


        public async Task HandlerExecuteAsync(ChooseTicket command)
        {
            var ticket = await _ticketRepository.GetByIdAsync(command.TicketId);
            if(ticket is null)
            {
                throw new TicketNotFoundException(command.TicketId);
            }

            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);
            if(customer is null)
            {
                throw new CustomerNotFoundException(command.CustomerId);
            }

            customer.SetTicket(ticket.Id);

            await _customerRepository.UpdateUserAsync(customer);
        }
    }
}
