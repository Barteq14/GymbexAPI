using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Tickets;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Tickets;
using Gymbex.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ICommandHandler<CreateTicket> _createTicketCommandHandler;
        private readonly ICommandHandler<DeleteTicket> _deleteTicketCommandHandler;
        private readonly ICommandHandler<BuyTicket> _buyTicketCommandHandler;
        private readonly ICommandHandler<UpdateTicketName> _updateTicketNameCommandHandler;
        private readonly IQueryHandler<GetTicket, TicketDto> _getTicketQueryHandler;
        private readonly IQueryHandler<GetTickets, IEnumerable<TicketDto>> _getTicketsQueryHandler;

        public TicketController(ICommandHandler<CreateTicket> createTicketCommandHandler, ICommandHandler<DeleteTicket> deleteTicketCommandHandler, IQueryHandler<GetTicket, TicketDto> getTicketQueryHandler, IQueryHandler<GetTickets, IEnumerable<TicketDto>> getTicketsQueryHandler, ICommandHandler<BuyTicket> buyTicketCommandHandler, ICommandHandler<UpdateTicketName> updateTicketNameCommandHandler)
        {
            _createTicketCommandHandler = createTicketCommandHandler;
            _deleteTicketCommandHandler = deleteTicketCommandHandler;
            _getTicketQueryHandler = getTicketQueryHandler;
            _getTicketsQueryHandler = getTicketsQueryHandler;
            _buyTicketCommandHandler = buyTicketCommandHandler;
            _updateTicketNameCommandHandler = updateTicketNameCommandHandler;
        }

        [SwaggerOperation("Get specify ticket by ID")]
        [HttpGet("{ticketId:guid}")]
        public async Task<ActionResult<TicketDto>> Get([FromRoute] Guid ticketId)
        {
            var ticket = await _getTicketQueryHandler.ExecuteHandleAsync(new GetTicket() { Id = ticketId });
            return Ok(ticket);
        }

        [SwaggerOperation("Get all tickets from DB")]
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

        [SwaggerOperation("Create new ticket")]
        [HttpPost]
        public async Task<ActionResult> Post(CreateTicket command)
        {
            command = command with { ticketId = Guid.NewGuid() };
            await _createTicketCommandHandler.HandlerExecuteAsync(command);

            return Ok();
        }

        [SwaggerOperation("Delete tikcet by ID")]
        [HttpDelete("{ticketId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid ticketId)
        {
            await _deleteTicketCommandHandler.HandlerExecuteAsync(new DeleteTicket(ticketId));
            return NoContent();
        }

        [Authorize]
        [SwaggerOperation("Get ticket by user")]
        [HttpPost("get-ticket/{ticketId:guid}")]
        public async Task<ActionResult> GetTicketByUser([FromRoute] Guid ticketId, BuyTicket command)
        {
            var currentCustomerId = Guid.Parse(HttpContext.User.Identity.Name);
            command = command with { TicketId = ticketId, CustomerId = currentCustomerId};
            await _buyTicketCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }

        [HttpPut("update-ticket/{ticketId:guid}")]
        public async Task<ActionResult> UpdateTicket([FromRoute] Guid ticketId, [FromBody] UpdateTicketName command)
        {
            command = command with { TicketId = ticketId };
            await _updateTicketNameCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
    }
}
