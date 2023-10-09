using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Exceptions;
using Gymbex.Core.Entities;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Commands.Reservations.Handlers
{
    public sealed class CreateReservationHandler : ICommandHandler<CreateReservation>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IActivityRepository _activityRepository;

        public CreateReservationHandler(IReservationRepository reservationRepository, ICustomerRepository customerRepository, IActivityRepository activityRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _activityRepository = activityRepository;
        }

        public async Task HandlerExecuteAsync(CreateReservation command)
        {
            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException(command.CustomerId);
            }

            var activity = await _activityRepository.GetActivityByIdAsync(command.ActivityId);
            if (activity == null)
            {
                throw new ActivityNotFoundException(command.ActivityId);
            }

            var activities = await _activityRepository.GetAllActivitiesAsync();
            var reservationsExist = activities.SelectMany(x => x.Reservations);

            if(reservationsExist.Any(x => x.ActivityId == new ActivityId(command.ActivityId) 
                                       && x.CustomerId == new CustomerId(command.CustomerId)))
            {
                throw new ReservationAlreadyExistsException(command.ActivityId);
            }

            var newReservation =
                new Reservation(command.ReservationId, new Date(DateTime.UtcNow), customer.Id, activity.Id);

            await _reservationRepository.AddAsync(newReservation);
        }
    }
}
