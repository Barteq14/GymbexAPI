using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Customers;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Gymbex.Application.Security;
using Gymbex.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpCommandHandler;
        private readonly ICommandHandler<DeleteCustomer> _deleteCustomerCommandHandler;
        private readonly ICommandHandler<UpdateCustomer> _updateCustomerCommandHandler;
        private readonly IQueryHandler<GetCustomer, CustomerDto> _getCustomerByIdQueryHandler;
        private readonly IQueryHandler<GetCustomers, IEnumerable<CustomerDto>> _getCustomersQueryHandler;
        private readonly ICommandHandler<SignIn> _signInCommandHandler;
        private readonly ITokenStorage _tokenStorage;

        public CustomerController(ICommandHandler<SignUp> signUpCommandHandler, ICommandHandler<DeleteCustomer> deleteCustomerCommandHandler, IQueryHandler<GetCustomer, CustomerDto> getCustomerByIdQueryHandler, IQueryHandler<GetCustomers, IEnumerable<CustomerDto>> getCustomersQueryHandler, ICommandHandler<SignIn> signInCommandHandler, ITokenStorage tokenStorage, ICommandHandler<UpdateCustomer> updateCustomerCommandHandler)
        {
            _signUpCommandHandler = signUpCommandHandler;
            _deleteCustomerCommandHandler = deleteCustomerCommandHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            _getCustomersQueryHandler = getCustomersQueryHandler;
            _signInCommandHandler = signInCommandHandler;
            _tokenStorage = tokenStorage;
            _updateCustomerCommandHandler = updateCustomerCommandHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get([FromQuery] GetCustomers query)
        {
            var customers = await _getCustomersQueryHandler.ExecuteHandleAsync(query);
            if (customers is null || !customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
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

        [HttpPost("sign-up")]
        public async Task<ActionResult<RegisterResult>> Post([FromBody] SignUp command)
        {
            try
            {
                command = command with { CustomerId = Guid.NewGuid() };
                await _signUpCommandHandler.HandlerExecuteAsync(command);
                return Ok(new RegisterResult { IsSuccess = true });
            }
            catch (UserWirhThisUsernameIsAlreadyExistException)
            {
                return BadRequest(new RegisterResult { IsSuccess = false, Error = "Nazwa użytkownika jest już zajęta" });
            }
            catch (UserWithThisEmailIsAlreadyExistException)
            {
                return BadRequest(new RegisterResult { IsSuccess = false, Error = "Email jest już zajęty" });
            }
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<LoginResult>> Post([FromBody] SignIn command)
        {
            try
            {
                await _signInCommandHandler.HandlerExecuteAsync(command);
                var jwt = _tokenStorage.GetJwt();
                return Ok(new LoginResult { Token = jwt.AccessToken, IsSuccess = true});
            }
            catch (InvalidCredentialException)
            {
                return BadRequest(new LoginResult { IsSuccess = false, Error = "Nieprawidłowy login lub hasło" });
            }
            
        }

        [HttpDelete("{customerId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid customerId)
        {
            var command = new DeleteCustomer(customerId);
            await _deleteCustomerCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCustomerResult>> Put([FromBody] UpdateCustomer command)
        {
            await _updateCustomerCommandHandler.HandlerExecuteAsync(command);

            return Ok(new UpdateCustomerResult { IsSuccess = true});
        }
    }
}
