using Gymbex.Core.Entities;
using Gymbex.Core.Enums.Extensions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Tests.Unit.Entities
{
    public sealed class AcivityTests
    {
        private readonly Activity _activity;
        private readonly Customer _customer;
        private readonly Ticket _ticket;
        public AcivityTests()
        {
            _ticket = Ticket.Create(Guid.NewGuid(), TicketKindEnum.Month, TicketKindEnum.Month.GetDisplayName());
            _activity = Activity.Create(Guid.NewGuid(), "Gym Excercises", new Date(new DateTime(2023,10,11)));
            _customer = Customer.Create(Guid.NewGuid(), "bartolomeo", "secret-bartolomeo", "Bartek Kalon", "bartolomeo@gymbex.io", "999888777", Role.User(), _ticket.Id);
        }

        [Fact]
        public void given_reservation_for_already_exists_should_be_fail()
        {
            #region Arrange
            var reservationFirst = new Reservation(Guid.NewGuid(), DateTime.UtcNow, _customer.Id, _activity.Id);
            #endregion

            #region Act
            var reservationSecond = new Reservation(Guid.NewGuid(), DateTime.UtcNow, _customer.Id, _activity.Id);
            #endregion

            #region Assertion
            var exception = Record.Exception(() => _activity.AddReservation(reservationSecond));
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ReservationAlreadyExistsException>();
            #endregion

        }

        [Fact]
        public void given_change_activity_date_should_be_success()
        {
            var newDate = new Date(new DateTime(2023,10,15));

            _activity.ChangeActivityDate(newDate);

            _activity.Date.ShouldBeEquivalentTo(newDate);
        }
    }
}
