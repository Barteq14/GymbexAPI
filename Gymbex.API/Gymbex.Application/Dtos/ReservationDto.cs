using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Dtos
{
    public sealed class ReservationDto
    {
        public Guid ReservationId { get; set; }
        public string ActivityName { get; set; }
        public Date ActivityDate { get; set; }
        public Date CreatedAt { get; set; }
    }
}
