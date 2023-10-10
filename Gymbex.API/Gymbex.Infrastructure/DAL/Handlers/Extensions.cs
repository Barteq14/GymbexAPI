using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Core.Entities;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public static class Extensions
    {
        public static ActivityDto AsActivityDto(this Activity activity)
        {
            return activity is not null ? new ActivityDto()
            {
                Id = activity.Id,
                Name = activity.Name,
                Date = activity.Date
            } : null;
        }

        public static CustomerDto AsCustomerDto(this Customer customer)
        {
            return new CustomerDto()
            {
                Id = customer.Id,
                Username = customer.Username,
                Email = customer.Email,
                FullName = customer.Fullname,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public static TicketDto AsTicketDto(this Ticket ticket)
        {
            return new TicketDto()
            {
                TicketId = ticket.Id,
                TicketKindEnum = ticket.Kind,
                KindDisplayName = ticket.KindDescription,
                Customers = ticket.Customers.Select(x => x.AsCustomerDto()).ToList(),
            };
        }
    }
}
