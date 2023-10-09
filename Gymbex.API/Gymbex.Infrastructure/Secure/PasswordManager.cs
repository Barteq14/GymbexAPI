using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Security;
using Gymbex.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Gymbex.Infrastructure.Secure
{
    internal sealed class PasswordManager : IPasswordManager
    {
        private readonly IPasswordHasher<Customer> _passwordHasher;

        public PasswordManager(IPasswordHasher<Customer> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string Secure(string password)
            => _passwordHasher.HashPassword(default, password);

        public bool Validate(string password, string securedPassword)
        {
            var x =_passwordHasher.VerifyHashedPassword(default, securedPassword, password)
                is PasswordVerificationResult.Success;

            return x;
        }
    }
}
