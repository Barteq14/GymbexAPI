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
        ICommandHandler<CreateEquipment> createEquipmentCommandHandler,
        ICommandHandler<UpdateEquipment> updateEquipmentCommandHandler,
        ICommandHandler<RemoveEquipment> removeEquipmentCommandHandler
        ) : ControllerBase
    {

        #region GET
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
        #endregion

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

        #region PUT
        [HttpPut("edit-equipment/{equipmentId:guid}")]
        public async Task<ActionResult> Put([FromRoute] Guid equipmentId, [FromBody] UpdateEquipment command)
        {
            command = command with { EquipmentId = equipmentId };
            await updateEquipmentCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("delete-equipment/{equipmentId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid equipmentId)
        {
            var command = new RemoveEquipment(equipmentId);
            await removeEquipmentCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
        #endregion
    }
}
