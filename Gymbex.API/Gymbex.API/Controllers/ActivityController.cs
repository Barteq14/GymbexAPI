using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Activities;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Activities;
using Gymbex.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Gymbex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IQueryHandler<GetActivities, IEnumerable<ActivityDto>> _getActivitiesQueryHandler;
        private readonly ICommandHandler<CreateNewActivity> _createNewActivityCommandHandler;
        private readonly ICommandHandler<DeleteActivityById> _deleteActivityByIdCommandHandler;
        private readonly IQueryHandler<GetActivityById, ActivityDto> _getActivityByIdQueryHandler;
        private readonly ICommandHandler<ChangeDateForActivity> _changeDateForActivityCommandHandler;
        private readonly ICommandHandler<RegistrationForActivity> _registrationForActivityCommandHandler;

        public ActivityController(IQueryHandler<GetActivities,IEnumerable<ActivityDto>> getActivitiesQueryHandler, ICommandHandler<CreateNewActivity> createNewActivityCommandHandler, ICommandHandler<DeleteActivityById> deleteActivityByIdCommandHandler, IQueryHandler<GetActivityById, ActivityDto> getActivityByIdQueryHandler, ICommandHandler<ChangeDateForActivity> channgeDateForActivityCommandHandler, ICommandHandler<RegistrationForActivity> registrationForActivityCommandHandler)
        {
            _getActivitiesQueryHandler = getActivitiesQueryHandler;
            _createNewActivityCommandHandler = createNewActivityCommandHandler;
            _deleteActivityByIdCommandHandler = deleteActivityByIdCommandHandler;
            _getActivityByIdQueryHandler = getActivityByIdQueryHandler;
            _changeDateForActivityCommandHandler = channgeDateForActivityCommandHandler;
            _registrationForActivityCommandHandler = registrationForActivityCommandHandler;
        }



        [SwaggerOperation("Get activity by ID")]
        [HttpGet("{activityId:guid}")]
        public async Task<ActionResult<ActivityDto>> Get([FromRoute]Guid activityId, [FromQuery] GetActivityById query)
        {
            query.Id = activityId;
            var activity = await _getActivityByIdQueryHandler.ExecuteHandleAsync(query);
            if (activity is null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [SwaggerOperation("Get activities as dtos")]
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

        [Authorize(Policy = "is-admin")]
        [SwaggerOperation("Create new activity")]
        [HttpPost]
        public async Task<ActionResult> Post(CreateNewActivity command)
        {
            command = command with { ActivityId = Guid.NewGuid() };
            await _createNewActivityCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }

        [SwaggerOperation("Change activity date with a new date value")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ChangeDateForActivity command)
        {
            await _changeDateForActivityCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }

        [Authorize(Policy = "is-admin")]
        [SwaggerOperation("Delete activity by ID")]
        [HttpDelete("{activityId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid activityId)
        {
            await _deleteActivityByIdCommandHandler.HandlerExecuteAsync(new DeleteActivityById(activityId));
            return NoContent();
        }

        [SwaggerOperation("Registration for activity")]
        [HttpPost("registration-activity/{activityId:guid}")]
        public async Task<ActionResult<ReservationResponseDto>> ReserveActivity([FromRoute] Guid activityId, RegistrationForActivity command)
        {
            //var currentCustomerId = Guid.Parse(HttpContext.User.Identity.Name);

            //command = command with { ActivityId = activityId, CustomerId = currentCustomerId};

            try
            {
                await _registrationForActivityCommandHandler.HandlerExecuteAsync(command);
                return Ok(new ReservationResponseDto { IsSuccess = true, Message = "Właśnie zapisałeś się na zajęcia."});
            }
            catch (ActivityNotFoundException)
            {
                return BadRequest(new ReservationResponseDto { IsSuccess = false, Error = "Nie znaleziono takich zajęć" });
            }
            catch (CustomerNotFoundException)
            {
                return BadRequest(new ReservationResponseDto { IsSuccess = false, Error = "Nie znaleziono użytkownika" });
            }
            catch (ReservationAlreadyExistsException)
            {
                return BadRequest(new ReservationResponseDto { IsSuccess = false, Error = "Reserwacja na te zajęcia już istnieje" });
            }

        }
    }
}
