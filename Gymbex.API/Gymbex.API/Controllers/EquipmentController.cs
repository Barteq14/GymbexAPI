using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Equipments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IQueryHandler<GetEquipments, List<EquipmentDto>> _getEquipmentsQueryHandler;

        public EquipmentController(IQueryHandler<GetEquipments,List<EquipmentDto>> getEquipmentsQueryHandler)
        {
            _getEquipmentsQueryHandler = getEquipmentsQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipmentDto>>> Get([FromQuery] GetEquipments query)
        {
            var equipments = await _getEquipmentsQueryHandler.ExecuteHandleAsync(query);

            if(equipments == null)
            {
                return NotFound();
            }

            return Ok(equipments);
        }
    }
}
