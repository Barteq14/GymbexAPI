using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Exceptions;
using Gymbex.Core.Repositories;

namespace Gymbex.Application.Commands.Activities.Handlers
{
    internal sealed class DeleteActivityHandler : ICommandHandler<DeleteActivityById>
    {
        private readonly IActivityRepository _activityRepository;

        public DeleteActivityHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task HandlerExecuteAsync(DeleteActivityById command)
        {
            var activity = await _activityRepository.GetActivityByIdAsync(command.ActivityId);
            if (activity is null)
            {
                throw new ActivityNotFoundException(command.ActivityId);
            }

            await _activityRepository.DeleteActivityByIdAsync(activity);
        }
    }
}
