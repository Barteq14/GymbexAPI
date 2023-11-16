using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Equipments;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Equipments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController(
        IQueryHandler<GetEquipments, List<EquipmentDto>> getEquipmentsQueryHandler,
        ICommandHandler<CreateEquipment> createEquipmentCommandHandler
        ) : ControllerBase
    {
        [SwaggerOperation("Get all equipments from DB")]
        [HttpGet]
        public async Task<ActionResult<List<EquipmentDto>>> Get([FromQuery] GetEquipments query)
        {
            var equipments = await getEquipmentsQueryHandler.ExecuteHandleAsync(query);

            if(equipments == null)
            {
                return NotFound();
            }

            return Ok(equipments);
        }

        #region POST
        [SwaggerOperation("Create new equipment")]
        [HttpPost("add-equipment")]
        public async Task<ActionResult> Post([FromBody] CreateEquipment command)
        {
            command = command with { EquipmentId = Guid.NewGuid() };
            await createEquipmentCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
        #endregion
    }
}
