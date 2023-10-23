using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Entities
{
    public sealed class Activity
    {
        private readonly HashSet<Reservation> _reservations = new();
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
        public IEnumerable<Reservation> Reservations => _reservations;


        public Activity(ActivityId id, ActivityName name, Date date)
        {
            Id = id;
            Name = name;
            Date = date;
        }

        public static Activity Create(ActivityId id, ActivityName name, Date date)
            => new Activity(id, name, date);

        public void ChangeActivityDate(Date date) => Date = date;

        public void AddReservation(Reservation reservation)
        {
            if(_reservations.Any(x => x.CustomerId == reservation.CustomerId))
            {
                throw new ReservationAlreadyExistsException(reservation.ActivityId);
            }

            _reservations.Add(reservation);
        }

        public void ClearReservationsList()
        {
            _reservations.Clear();
        }
    }
}
