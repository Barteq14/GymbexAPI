using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Core.Repositories;

namespace Gymbex.Application.Commands.Handlers
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
            //sprawdzenie czy istnieje takie activity 
            
            await _activityRepository.DeleteActivityByIdAsync(command.ActivityId);
        }
    }
}
