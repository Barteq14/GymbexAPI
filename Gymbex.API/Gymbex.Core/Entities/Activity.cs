using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Entities
{
    public sealed class Activity
    {
        private static readonly HashSet<Reservation> _reservations = new();
        /// <summary>
        /// Id zajęć
        /// </summary>
        public ActivityId Id { get; private set; }
        /// <summary>
        /// Nazwa zajęć
        /// </summary>
        public ActivityName Name { get; private set; }
        /// <summary>
        /// Data odbywania się zajęć
        /// </summary>
        public Date Date { get; private set; }

        /// <summary>
        /// Lista użytkowników zapisanych na zajęcia
        /// </summary>
        public IEnumerable<Reservation> Reservations { get; private set; } = _reservations;


        public Activity(ActivityId id, ActivityName name, Date date)
        {
            Id = id;
            Name = name;
            Date = date;
        }

        public void ChangeActivityDate(Date date) => Date = date;
    }
}
