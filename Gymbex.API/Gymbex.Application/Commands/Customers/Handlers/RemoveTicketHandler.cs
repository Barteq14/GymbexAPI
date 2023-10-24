using Gymbex.Application.Abstractions;
using Gymbex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class RemoveTicketHandler : ICommandHandler<RemoveTIcket>
    {
        private readonly ICustomerRepository _customerRepository;

        public RemoveTicketHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task HandlerExecuteAsync(RemoveTIcket command)
        {
            await _customerRepository.RemoveTicketAsync(command.customerId);
            throw new NotImplementedException();
        }
    }
}
