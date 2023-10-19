using Gymbex.Application.Abstractions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class UpdateCustomerHandler : ICommandHandler<UpdateCustomer>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task HandlerExecuteAsync(UpdateCustomer command)
        {
            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);
            if(customer is null)
            {
                throw new CustomerNotFoundException(command.CustomerId);
            }

            customer.UpdateCustomer(command.Fullname, command.Username, command.Phone);

            await _customerRepository.UpdateUserAsync(customer);
        }
    }
}
