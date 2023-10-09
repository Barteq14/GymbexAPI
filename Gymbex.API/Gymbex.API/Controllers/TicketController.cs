using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Tickets;
using Gymbex.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ICommandHandler<CreateTicket> _createTicketCommandHandler;
        private readonly ICommandHandler<DeleteTicket> _deleteTicketCommandHandler;

        public TicketController(ICommandHandler<CreateTicket> createTicketCommandHandler, ICommandHandler<DeleteTicket> deleteTicketCommandHandler)
        {
            _createTicketCommandHandler = createTicketCommandHandler;
            _deleteTicketCommandHandler = deleteTicketCommandHandler;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateTicket command)
        {
            command = command with { ticketId = Guid.NewGuid() };
            await _createTicketCommandHandler.HandlerExecuteAsync(command);

            return Ok();
        }

        [HttpDelete("{ticketId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid ticketId)
        {
            await _deleteTicketCommandHandler.HandlerExecuteAsync(new DeleteTicket(ticketId));
            return NoContent();
        }
    }
}
