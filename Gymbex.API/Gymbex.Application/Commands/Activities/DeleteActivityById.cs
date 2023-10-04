using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands.Activities
{
    public sealed record DeleteActivityById(Guid ActivityId) : ICommand;
}
