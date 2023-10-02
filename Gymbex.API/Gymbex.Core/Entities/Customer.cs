using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Entities
{
    public sealed class Customer
    {
        /// <summary>
        /// Id użytkownika
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// Hasło użytkownika
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// Imię i nazwisko użytkownika
        /// </summary>
        public string Fullname { get; private set; }
        /// <summary>
        /// Email użytkownika
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// Numer telefonu
        /// </summary>
        public string PhoneNumber { get; private set; }

        #region Relationships
        public Guid TicketId { get; private set; }
        public Ticket Ticket { get; private set; }

        #endregion


        public Customer(Guid id, string username, string password, string fullname, string email, string phoneNumber, Guid ticketId, Ticket ticket)
        {
            Id = id;
            Username = username;
            Password = password;
            Fullname = fullname;
            Email = email;
            PhoneNumber = phoneNumber;
            TicketId = ticketId;
            Ticket = ticket;
        }
    }
}
