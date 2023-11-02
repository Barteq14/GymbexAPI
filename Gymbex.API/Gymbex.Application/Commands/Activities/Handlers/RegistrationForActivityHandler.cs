using Gymbex.Application.Abstractions;
using Gymbex.Core.Entities;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Activities.Handlers
{
    internal sealed class RegistrationForActivityHandler : ICommandHandler<RegistrationForActivity>
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICustomerRepository _customerRepository;

        public RegistrationForActivityHandler(IActivityRepository activityRepository, ICustomerRepository customerRepository)
        {
            _activityRepository = activityRepository;
            _customerRepository = customerRepository;
        }

        public async Task HandlerExecuteAsync(RegistrationForActivity command)
        {

            var activity = await _activityRepository.GetActivityByIdAsync(command.ActivityId);
            if(activity is null)
            {
                throw new ActivityNotFoundException(command.ActivityId);
            }

            var customer = await _customerRepository.GetUserByIdAsync(command.CustomerId);
            if(customer is null)
            {
                throw new CustomerNotFoundException(command.CustomerId);
            }

            if(activity.Reservations.Any(x => x.CustomerId == new CustomerId(command.CustomerId)))
            {
                throw new ReservationAlreadyExistsException(command.CustomerId);
            }

            var newReservation = new Reservation(Guid.NewGuid(), DateTime.UtcNow, command.CustomerId, command.ActivityId);

            activity.AddReservation(newReservation);
            customer.AddReservation(newReservation);

            await _activityRepository.UpdateActivityAsync(activity); 
            await _customerRepository.UpdateUserAsync(customer);
        }
    }
}
