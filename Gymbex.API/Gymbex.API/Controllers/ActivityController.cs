using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IQueryHandler<GetActivities, IEnumerable<ActivityDto>> _getActivitiesQueryHandler;
        private readonly ICommandHandler<CreateNewActivity> _createNewActivityCommandHandler;

        public ActivityController(IQueryHandler<GetActivities,IEnumerable<ActivityDto>> getActivitiesQueryHandler, ICommandHandler<CreateNewActivity> createNewActivityCommandHandler)
        {
            _getActivitiesQueryHandler = getActivitiesQueryHandler;
            _createNewActivityCommandHandler = createNewActivityCommandHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> Get([FromQuery] GetActivities query)
        {
            var activities = await _getActivitiesQueryHandler.ExecuteHandleAsync(query);
            if (activities.Any())
            {
                return Ok(activities);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateNewActivity command)
        {
            command = command with { ActivityId = Guid.NewGuid() };
            await _createNewActivityCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
    }
}
