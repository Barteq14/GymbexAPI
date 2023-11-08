using Gymbex.Application.Abstractions;
using Gymbex.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Customers
{
    public sealed record ChangeRoleByAdmin(Guid CustomerId, string Role) : ICommand;
}
