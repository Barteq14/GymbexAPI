using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Customers
{
    public sealed record SignIn(string Email, string Password) : ICommand;
}
