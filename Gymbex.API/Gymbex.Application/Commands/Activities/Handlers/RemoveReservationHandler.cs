using Gymbex.Application.Abstractions;
using Gymbex.Core.Repositories;
using Gymbex.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Activities.Handlers
{
    public sealed class RemoveReservationHandler(IReservationRepository reservationRepository, ICustomerRepository customerRepository) : ICommandHandler<RemoveReservation>
    {
        public async Task HandlerExecuteAsync(RemoveReservation command)
        {
            var reservation = await reservationRepository.GetAsync(command.ReservationId);
            if (reservation == null)
            {
                throw new ReservationNotFoundException(command.ReservationId);
            }

            var customer = reservation.Customer;
            customer.DeleteReservation(reservation);
            await customerRepository.UpdateUserAsync(customer);
            await reservationRepository.RemoveAsync(reservation);
        }
    }
}
