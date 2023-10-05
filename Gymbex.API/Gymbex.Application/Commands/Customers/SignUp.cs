using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Customers
{
    public sealed record SignUp(Guid CustomerId, string Username, string Password, string FullName, 
        string Email, string PhoneNumber, string Role, Guid? TicketId) : ICommand;
}
