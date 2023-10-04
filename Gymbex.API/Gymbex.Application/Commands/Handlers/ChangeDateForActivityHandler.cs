using Gymbex.Application.Abstractions;
using Gymbex.Application.Exceptions;
using Gymbex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Handlers
{
    public sealed class ChangeDateForActivityHandler : ICommandHandler<ChangeDateForActivity>
    {
        private readonly IActivityRepository _activityRepository;

        public ChangeDateForActivityHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task HandlerExecuteAsync(ChangeDateForActivity command)
        {
            var activity = await _activityRepository.GetActivityByIdAsync(command.ActivityId);

            if(activity is null)
            {
                throw new ActivityNotFoundException(command.ActivityId);
            }

            activity.ChangeActivityDate(command.ActivityDate);

            await _activityRepository.ChangeActivityDate(activity);
        }
    }
}
