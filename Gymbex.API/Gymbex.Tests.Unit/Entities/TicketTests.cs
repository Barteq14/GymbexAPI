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
    public sealed class TicketTests
    {
        [Fact]
        public void given_ticket_to_customer_when_customer_already_has_ticket_should_be_fail()
        {
            var ticket = Ticket.Create(Guid.NewGuid(), TicketKindEnum.Month, TicketKindEnum.Month.GetDisplayName());
            var customer = Customer.Create(Guid.NewGuid(), "bartolomeo", "secret-bartolomeo", "Bartek Kalon", "bartolomeo@gymbex.io", "999888777", Role.User(), ticket.Id);

            var exception = Record.Exception(() => ticket.AddTicketToCustomer(customer));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<TicketAlreadyExistsException>();
        }
    }
}
