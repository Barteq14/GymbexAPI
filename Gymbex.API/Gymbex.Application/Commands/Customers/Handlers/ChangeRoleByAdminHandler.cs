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
    public sealed class ChangeRoleByAdminHandler : ICommandHandler<ChangeRoleByAdmin>
    {
        private readonly ICustomerRepository _customerRepository;

        public ChangeRoleByAdminHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task HandlerExecuteAsync(ChangeRoleByAdmin command)
        {
            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);

            if(customer is null)
            {
                throw new CustomerNotFoundException();
            }

            customer.ChangeRoleByAdmin(command.Role);
            await _customerRepository.UpdateUserAsync(customer);
        }
    }
}
