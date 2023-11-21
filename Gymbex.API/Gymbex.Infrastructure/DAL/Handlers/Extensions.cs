using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Core.Entities;
using Gymbex.Core.Enums.Extensions;

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
                PhoneNumber = customer.PhoneNumber,
                TicketId = customer.TicketId is null ? null : customer.TicketId.Value,
                TicketName = customer.Ticket is null ? "Brak" : customer.Ticket.KindDescription,
                Role = customer.Role.Value
            };
        }

        public static TicketDto AsTicketDto(this Ticket ticket)
        {
            return new TicketDto()
            {
                TicketId = ticket.Id,
                KindDisplayName = ticket.KindDescription
            };
        }

        public static ReservationDto AsReservationDto(this Reservation reservation, Activity activity)
        {
            return new ReservationDto()
            {
                ReservationId = reservation.Id,
                ActivityName = activity.Name,
                ActivityDate = activity.Date,
                CustomerEmail = reservation.Customer.Email,
                CreatedAt = reservation.CreatedAt
            };
        }

        public static EquipmentDto AsEquipmentDto(this Equipment equipment)
        {
            return new EquipmentDto()
            {
                ID = equipment.Id,
                Name = equipment.Name,
                Description = equipment.Description,
                EquipmentState = equipment.EquipmentState.Value.GetDisplayName(),
                Quantity = equipment.Quantity,
                CategoryName = equipment.CategoryEquipment.Name
            };
        }

        public static CategoryEquipmentDto AsEquipmentsCategoryDto(this CategoryEquipment categoryEquipment)
        {
            return new CategoryEquipmentDto()
            {
                Id = categoryEquipment.Id,
                Name = categoryEquipment.Name
            };
        }
    }
}
