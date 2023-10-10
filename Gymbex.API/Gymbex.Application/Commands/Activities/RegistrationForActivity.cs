using Gymbex.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Activities
{
    public sealed record RegistrationForActivity(Guid ActivityId, Guid CustomerId) : ICommand;
}
