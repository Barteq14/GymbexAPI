using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Enums;
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
        /// Data ważności od
        /// </summary>
        public Date ImportantFrom { get; private set; }
        /// <summary>
        /// Data ważności do
        /// </summary>
        public Date ImportantTo { get; private set; }
        public IEnumerable<Customer> Customers { get; private set; } = _customers;

        public Ticket(Guid id, TicketKindEnum kind, DateTime importantFrom, DateTime importantTo)
        {
            Id = id;
            Kind = kind;
            ImportantFrom = importantFrom;
            ImportantTo = importantTo;
        }

        public void AddTicketToCustomer(Customer customer)
        {
            if(customer.TicketId is not null)
            {
                throw new TicketAlreadyExistsException(customer.Username);
            }
            _customers.Add(customer);
        }
    }
}
