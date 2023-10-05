using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Entities
{
    public sealed class Customer
    {
        private static readonly HashSet<Reservation> _reservations = new();
        /// <summary>
        /// Id użytkownika
        /// </summary>
        public CustomerId Id { get; private set; }
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        public Username Username { get; private set; }
        /// <summary>
        /// Hasło użytkownika
        /// </summary>
        public Password Password { get; private set; }
        /// <summary>
        /// Imię i nazwisko użytkownika
        /// </summary>
        public Fullname Fullname { get; private set; }
        /// <summary>
        /// Email użytkownika
        /// </summary>
        public Email Email { get; private set; }
        /// <summary>
        /// Numer telefonu
        /// </summary>
        public PhoneNumber PhoneNumber { get; private set; }

        #region Relationships
        public Guid? TicketId { get; private set; }
        public IEnumerable<Reservation> Reservations { get; private set; } = _reservations;
        #endregion


        public Customer(CustomerId id, Username username, Password password, Fullname fullname, Email email, PhoneNumber phoneNumber, Guid? ticketId)
        {
            Id = id;
            Username = username;
            Password = password;
            Fullname = fullname;
            Email = email;
            PhoneNumber = phoneNumber;
            TicketId = ticketId;
        }
    }
}
