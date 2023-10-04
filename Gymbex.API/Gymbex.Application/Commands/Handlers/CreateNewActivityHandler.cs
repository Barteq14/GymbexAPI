﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Exceptions;
using Gymbex.Application.Services;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;

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
            var activities = (await _activityRepository.GetAllActivitiesAsync()).ToList();

            var isExistTheSameActivityName = activities.Any(x => x.Name.Equals(command.ActivityName));
            if (isExistTheSameActivityName)
            {
                throw new ActivityAlreadyExistException(command.ActivityName);
            }

            if(activities.Any(x => x.Date == new Date(command.ReservationDateTime)))
            {
                throw new ActivityDateIsBusyException(command.ReservationDateTime);
            }

            var activity = new Activity(command.ActivityId, command.ActivityName, command.ReservationDateTime);
            await _activityRepository.CreateActivityAsync(activity);
        }
    }
}
