using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Entities
{
    public sealed class Reservation
    {
        /// <summary>
        /// Id rezerwacji
        /// </summary>
        public ReservationId Id { get; private set; }
        /// <summary>
        /// Data utworzenia rezerwacji
        /// </summary>
        public Date CreatedAt { get; private set; }

        #region Relationships

        public CustomerId CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public ActivityId ActivityId { get; private set; }
        public Activity Activity { get; private set; }

        #endregion

        public Reservation(ReservationId id, Date createdAt, CustomerId customerId, ActivityId activityId)
        {
            Id = id;
            CreatedAt = createdAt;
            CustomerId = customerId;
            ActivityId = activityId;
        }

       
    }
}
