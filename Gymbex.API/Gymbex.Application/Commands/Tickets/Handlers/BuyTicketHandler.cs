using Gymbex.Application.Abstractions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Tickets.Handlers
{
    public sealed class BuyTicketHandler : ICommandHandler<BuyTicket>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICustomerRepository _customerRepository;

        public BuyTicketHandler(ITicketRepository ticketRepository, ICustomerRepository customerRepository)
        {
            _ticketRepository = ticketRepository;
            _customerRepository = customerRepository;
        }

        public async Task HandlerExecuteAsync(BuyTicket command)
        {
            var ticket = await _ticketRepository.GetAsync(command.TicketId);
            if(ticket is null)
            {
                throw new TicketNotFoundException(command.TicketId);
            }

            if(ticket.Customers.Any(x => x.Id == new CustomerId(command.CustomerId)))
            {
                throw new CustomerAlreadyHasTicketException();
            }

            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);
            if(customer is null)
            {
                throw new CustomerNotFoundException(command.CustomerId);
            }

            if(customer.TicketId is not null)
            {
                throw new TicketAlreadyExistsException(customer.Username);
            }

            ticket.AddTicketToCustomer(customer);
            await _ticketRepository.UpdateAsync(ticket);
        }
    }
}
