using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Customers;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpCommandHandler;
        private readonly ICommandHandler<DeleteCustomer> _deleteCustomerCommandHandler;
        private readonly IQueryHandler<GetCustomer, CustomerDto> _getCustomerByIdQueryHandler;

        public CustomerController(ICommandHandler<SignUp> signUpCommandHandler, ICommandHandler<DeleteCustomer> deleteCustomerCommandHandler, IQueryHandler<GetCustomer, CustomerDto> getCustomerByIdQueryHandler)
        {
            _signUpCommandHandler = signUpCommandHandler;
            _deleteCustomerCommandHandler = deleteCustomerCommandHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
        }

        [HttpGet("{customerId:guid}")]
        public async Task<ActionResult<CustomerDto>> Get([FromRoute] Guid customerId, [FromQuery] GetCustomer query)
        {
            query.Id = customerId;
            var customer = await _getCustomerByIdQueryHandler.ExecuteHandleAsync(query);
            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignUp command)
        {
            command = command with { CustomerId = Guid.NewGuid() };
            await _signUpCommandHandler.HandlerExecuteAsync(command);
            return Ok();
        }

        [HttpDelete("{customerId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid customerId)
        {
            var command = new DeleteCustomer(customerId);
            await _deleteCustomerCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
    }
}
