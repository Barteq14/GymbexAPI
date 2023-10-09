using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Tickets;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Tickets;
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
        private readonly IQueryHandler<GetTicket, TicketDto> _getTicketQueryHandler;
        private readonly IQueryHandler<GetTickets, IEnumerable<TicketDto>> _getTicketsQueryHandler;

        public TicketController(ICommandHandler<CreateTicket> createTicketCommandHandler, ICommandHandler<DeleteTicket> deleteTicketCommandHandler, IQueryHandler<GetTicket, TicketDto> getTicketQueryHandler, IQueryHandler<GetTickets, IEnumerable<TicketDto>> getTicketsQueryHandler)
        {
            _createTicketCommandHandler = createTicketCommandHandler;
            _deleteTicketCommandHandler = deleteTicketCommandHandler;
            _getTicketQueryHandler = getTicketQueryHandler;
            _getTicketsQueryHandler = getTicketsQueryHandler;
        }

        [HttpGet("{ticketId:guid}")]
        public async Task<ActionResult<TicketDto>> Get([FromRoute] Guid ticketId)
        {
            var ticket = await _getTicketQueryHandler.ExecuteHandleAsync(new GetTicket() { Id = ticketId });
            return Ok(ticket);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> Get([FromQuery] GetTickets query)
        {
            var tickets = await _getTicketsQueryHandler.ExecuteHandleAsync(query);
            if (tickets == null)
            {
                return NotFound();
            }
            return Ok(tickets);
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
