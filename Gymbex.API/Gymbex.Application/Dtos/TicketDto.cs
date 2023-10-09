using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Enums;

namespace Gymbex.Application.Dtos
{
    public sealed class TicketDto
    {
        public Guid TicketId { get; set; }
        public TicketKindEnum TicketKindEnum { get; set; }
        public string KindDisplayName { get; set; }
    }
}
