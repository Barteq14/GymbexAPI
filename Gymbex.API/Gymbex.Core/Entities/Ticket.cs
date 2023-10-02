using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Enums;

namespace Gymbex.Core.Entities
{
    public sealed class Ticket
    {
        /// <summary>
        /// Id karnetu
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Rodzaj biletu (enum)
        /// </summary>
        public TicketKindEnum Kind { get; private set; }
        /// <summary>
        /// Data ważności od
        /// </summary>
        public DateTime ImportantFrom { get; private set; }
        /// <summary>
        /// Data ważności do
        /// </summary>
        public DateTime ImportantTo { get; private set; }

        public Ticket(Guid id, TicketKindEnum kind, DateTime importantFrom, DateTime importantTo)
        {
            Id = id;
            Kind = kind;
            ImportantFrom = importantFrom;
            ImportantTo = importantTo;
        }
    }
}
