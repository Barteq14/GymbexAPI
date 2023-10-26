using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Customers;
using Gymbex.Application.Commands.Tickets;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Gymbex.Application.Security;
using Gymbex.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        private readonly IQueryHandler<GetInstructors, List<CustomerDto>> _getInstructorsQueryHandler;
        private readonly ICommandHandler<SignIn> _signInCommandHandler;
        private readonly ICommandHandler<BuyTicket> _buyTicketCommandHandler;
        private readonly ICommandHandler<RemoveTIcket> _removeTicketCommandHandler;
        private readonly ITokenStorage _tokenStorage;

        public CustomerController(ICommandHandler<SignUp> signUpCommandHandler, ICommandHandler<DeleteCustomer> deleteCustomerCommandHandler, IQueryHandler<GetCustomer, CustomerDto> getCustomerByIdQueryHandler, IQueryHandler<GetCustomers, IEnumerable<CustomerDto>> getCustomersQueryHandler, ICommandHandler<SignIn> signInCommandHandler, ITokenStorage tokenStorage, ICommandHandler<UpdateCustomer> updateCustomerCommandHandler, ICommandHandler<BuyTicket> buyTicketCommandHandler, ICommandHandler<RemoveTIcket> removeTicketCommandHandler, IQueryHandler<GetInstructors, List<CustomerDto>> getInstructorsQueryHandler)
        {
            _signUpCommandHandler = signUpCommandHandler;
            _deleteCustomerCommandHandler = deleteCustomerCommandHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            _getCustomersQueryHandler = getCustomersQueryHandler;
            _signInCommandHandler = signInCommandHandler;
            _tokenStorage = tokenStorage;
            _updateCustomerCommandHandler = updateCustomerCommandHandler;
            _buyTicketCommandHandler = buyTicketCommandHandler;
            _removeTicketCommandHandler = removeTicketCommandHandler;
            _getInstructorsQueryHandler = getInstructorsQueryHandler;
        }

        #region GET
        [SwaggerOperation("Pobranie wszystkich użytkowników")]
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

        [SwaggerOperation("Pobranie użytkownika z danym ID")]
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

        [HttpGet("instructors")]
        public async Task<ActionResult<List<CustomerDto>>> GetInstructors([FromQuery] GetInstructors query)
        {
            var instructors = await _getInstructorsQueryHandler.ExecuteHandleAsync(query);
            return Ok(instructors);
        }
        #endregion

        #region POST
        [SwaggerOperation("Rejestracja użytkownika")]
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

        [SwaggerOperation("Logowanie użytkownika")]
        [HttpPost("sign-in")]
        public async Task<ActionResult<LoginResult>> Post([FromBody] SignIn command)
        {
            try
            {
                await _signInCommandHandler.HandlerExecuteAsync(command);
                var jwt = _tokenStorage.GetJwt();
                return Ok(new LoginResult { Token = jwt.AccessToken, IsSuccess = true });
            }
            catch (InvalidCredentialException)
            {
                return BadRequest(new LoginResult { IsSuccess = false, Error = "Nieprawidłowy login lub hasło" });
            }

        }

        [SwaggerOperation("Wybranie i przypisanie karnetu")]
        [HttpPost("choose-ticket")]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] BuyTicket command)
        {
            try
            {
                await _buyTicketCommandHandler.HandlerExecuteAsync(command);
                return Ok(new ResponseModel { IsSuccess = true });
            }
            catch (TicketNotFoundException)
            {
                return BadRequest(new ResponseModel { IsSuccess = false, Error = "Nie znaleziono takiego karnetu." });
            }
            catch (CustomerAlreadyHasTicketException)
            {
                return BadRequest(new ResponseModel { IsSuccess = false, Error = "Już posiadasz karnet." });
            }
            catch (TicketAlreadyExistsException)
            {
                return BadRequest(new ResponseModel { IsSuccess = false, Error = "Już posiadasz karnet." });
            }
        }
        #endregion

        #region PUT
        [SwaggerOperation("Aktualizacja użytkownika")]
        [HttpPut]
        public async Task<ActionResult<UpdateCustomerResult>> Put([FromBody] UpdateCustomer command)
        {
            await _updateCustomerCommandHandler.HandlerExecuteAsync(command);

            return Ok(new UpdateCustomerResult { IsSuccess = true });
        }



        [SwaggerOperation("Rezygnacja z karnetu")]
        [HttpPut("remove-ticket")]
        public async Task<ActionResult> RemoveTicketFromCustomer([FromBody] RemoveTIcket command)
        {
            await _removeTicketCommandHandler.HandlerExecuteAsync(command);
            //tutaj trzeba zrobić usunięcie ticketu od customera
            return NoContent();
        }
        #endregion

        #region DELETE
        [SwaggerOperation("Usuwanie użytkownika o danym ID")]
        [HttpDelete("{customerId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid customerId)
        {
            var command = new DeleteCustomer(customerId);
            await _deleteCustomerCommandHandler.HandlerExecuteAsync(command);
            return NoContent();
        }
        #endregion
    }
}
