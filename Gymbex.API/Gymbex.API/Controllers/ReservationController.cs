using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Activities;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IQueryHandler<GetReservations, List<ReservationDto>> _getReservationsQueryHandler;
        private readonly ICommandHandler<RemoveReservation> _removeReservationCommandHandler;

        public ReservationController(IQueryHandler<GetReservations, List<ReservationDto>> getReservationsQueryHandler, ICommandHandler<RemoveReservation> removeReservationCommandHandler)
        {
            _getReservationsQueryHandler = getReservationsQueryHandler;
            _removeReservationCommandHandler = removeReservationCommandHandler;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDto>>> Get([FromQuery] GetReservations query)
        {
            var list = await _getReservationsQueryHandler.ExecuteHandleAsync(query);
            return Ok(list);
        }

        [HttpDelete("{reservationId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid reservationId)
        {
            var command = new RemoveReservation(reservationId);
            await _removeReservationCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
    }
}
