using Gymbex.Application.Abstractions;
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

        public ActivityController(IQueryHandler<GetActivities,IEnumerable<ActivityDto>> getActivitiesQueryHandler)
        {
            _getActivitiesQueryHandler = getActivitiesQueryHandler;
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

        [HttpGet("{activityId:guid}")]
        public async Task<ActionResult<ActivityDto>> Get([FromBody] )
    }
}
