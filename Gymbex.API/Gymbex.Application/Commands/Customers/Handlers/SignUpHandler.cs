using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Customers.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        public SignUpHandler()
        {
                
        }

        public Task HandlerExecuteAsync(SignUp command)
        {
            throw new NotImplementedException();
        }
    }
}
