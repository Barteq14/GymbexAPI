using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class DeleteCustomerHandler : ICommandHandler<DeleteCustomer>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task HandlerExecuteAsync(DeleteCustomer command)
        {
            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);
            if (customer is null)
            {
                throw new CustomerNotFoundException(command.CustomerId);
            }

            await _customerRepository.DeleteUserAsync(customer);
        }
    }
}
