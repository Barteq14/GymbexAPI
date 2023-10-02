using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Services;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;

namespace Gymbex.Application.Commands.Handlers
{
    internal sealed class CreateNewActivityHandler : ICommandHandler<CreateNewActivity>
    {
        private readonly  IActivityRepository _activityRepository;

        public CreateNewActivityHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task HandlerExecuteAsync(CreateNewActivity command)
        {
            var activity = new Activity(command.ActivityId, command.ActivityName, command.ReservationDateTime);
            await _activityRepository.CreateActivity(activity);
        }
    }
}
