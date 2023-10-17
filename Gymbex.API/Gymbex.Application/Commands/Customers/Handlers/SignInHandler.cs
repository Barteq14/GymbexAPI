using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Security;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public SignInHandler(ICustomerRepository customerRepository, IAuthenticator authenticator, IPasswordManager passwordManager, IHttpContextAccessor httpContextAccessor, ITokenStorage tokenStorage)
        {
            _customerRepository = customerRepository;
            _authenticator = authenticator;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }

        public async Task HandlerExecuteAsync(SignIn command)
        {
            var customer = await _customerRepository.GetUserByEmailAsync(command.Email);
            if (customer is null)
            {
                throw new InvalidCredentialException();
            }

            if (!_passwordManager.Validate(command.Password, customer.Password))
            {
                throw new InvalidCredentialException();
            }

            var accessToken = _authenticator.CreateToken(customer.Id.Id, customer.Role, customer.Email);
            _tokenStorage.Set(accessToken);
        }
    }
}
