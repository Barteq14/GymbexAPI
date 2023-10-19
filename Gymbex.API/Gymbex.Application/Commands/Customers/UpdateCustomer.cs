using Gymbex.Application.Abstractions;
using Gymbex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Customers
{
    public sealed record UpdateCustomer(Guid CustomerId, string Fullname, string Username, string Phone) : ICommand;
}
