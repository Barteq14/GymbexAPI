using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;

namespace Gymbex.Application.Commands
{
    public sealed record CreateNewActivity(Guid ActivityId, DateTime ReservationDateTime, 
        string ActivityName) : ICommand;
}
