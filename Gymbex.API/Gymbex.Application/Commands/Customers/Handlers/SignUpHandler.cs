using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Security;
using Gymbex.Core.Entities;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordManager _passwordManager;

        public SignUpHandler(ICustomerRepository customerRepository, IPasswordManager passwordManager)
        {
            _customerRepository = customerRepository;
            _passwordManager = passwordManager;
        }

        public async Task HandlerExecuteAsync(SignUp command)
        {
            var email = command.Email;
            var username = command.Username;
            var password = command.Password;

            if (await _customerRepository.GetUserByUsernameAsync(username) is not null)
            {
                throw new UserWirhThisUsernameIsAlreadyExistException(username);
            }

            if (await _customerRepository.GetUserByEmailAsync(email) is not null)
            {
                throw new UserWithThisEmailIsAlreadyExistException(email);
            }

            var hashedPassword = _passwordManager.Secure(password);

            var user = new Customer(command.CustomerId, command.Username, hashedPassword, command.FullName,
                command.Email, command.PhoneNumber, string.IsNullOrEmpty(command.Role) ? Role.User() : command.Role, command.TicketId);

            await _customerRepository.AddAsync(user);
        }
    }
}
