using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class SignInHandler : ICommandHandler<SignIn>
    {
        
        public Task HandlerExecuteAsync(SignIn command)
        {
            throw new NotImplementedException();
        }
    }
}
