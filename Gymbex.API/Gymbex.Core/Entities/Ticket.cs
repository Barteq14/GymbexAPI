using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Enums;
using Gymbex.Core.Enums.Extensions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Entities
{
    public sealed class Ticket
    {
        private static readonly HashSet<Customer> _customers = new();
        /// <summary>
        /// Id karnetu
        /// </summary>
        public TicketId Id { get; private set; }
        /// <summary>
        /// Rodzaj biletu (enum)
        /// </summary>
        public TicketKindEnum Kind { get; private set; }
        /// <summary>
        /// Opis rodzaju karnetu
        /// </summary>
        public string KindDescription { get; private set; }
        public IEnumerable<Customer> Customers { get; private set; } = _customers;

        public Ticket(TicketId id, TicketKindEnum kind, string kindDescription)
        {
            Id = id;
            Kind = kind;
            KindDescription = kindDescription;
        }

        public static Ticket Create(TicketId id, TicketKindEnum kind, string kindDescription)
            => new(id, kind, kindDescription);

        public void AddTicketToCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}
