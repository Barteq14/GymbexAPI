using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Reservations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ICommandHandler<CreateReservation> _createReservationCommandHandler;

        public ReservationController(ICommandHandler<CreateReservation> createReservationCommandHandler)
        {
            _createReservationCommandHandler = createReservationCommandHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateReservation command)
        {
            command = command with { ReservationId = Guid.NewGuid() };
            await _createReservationCommandHandler.HandlerExecuteAsync(command);
            return Ok();
        }
    }
}
