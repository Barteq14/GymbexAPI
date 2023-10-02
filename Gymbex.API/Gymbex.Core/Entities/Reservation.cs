using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Entities
{
    public sealed class Reservation
    {
        /// <summary>
        /// Id rezerwacji
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Data utworzenia rezerwacji
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        #region Relationships

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public Guid ActivityId { get; private set; }
        public Activity Activity { get; private set; }

        #endregion

        public Reservation(Guid id, DateTime createdAt, Guid customerId, Customer customer, Guid activityId, Activity activity)
        {
            Id = id;
            CreatedAt = createdAt;
            CustomerId = customerId;
            Customer = customer;
            ActivityId = activityId;
            Activity = activity;
        }
    }
}
