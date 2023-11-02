using Gymbex.Application.Abstractions;
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

        public ReservationController(IQueryHandler<GetReservations, List<ReservationDto>> getReservationsQueryHandler)
        {
            _getReservationsQueryHandler = getReservationsQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDto>>> Get([FromQuery] GetReservations query)
        {
            var list = await _getReservationsQueryHandler.ExecuteHandleAsync(query);
            return Ok(list);
        }
    }
}
