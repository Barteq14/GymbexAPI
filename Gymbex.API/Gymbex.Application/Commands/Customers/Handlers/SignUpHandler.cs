using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly ICustomerRepository _customerRepository;

        public SignUpHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public Task HandlerExecuteAsync(SignUp command)
        //{
            //var user = new Customer(command.CustomerId, command.Username, command.Password, command.FullName,
            //    command.Email,
            //    command.PhoneNumber, null);
        //}
        public Task HandlerExecuteAsync(SignUp command)
        {
            throw new NotImplementedException();
        }
    }
}
