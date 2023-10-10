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
        public Guid ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime ActivityDate { get; set; }
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid TicketId { get; set; }
        public string TicketName { get; set; }
    }
}
