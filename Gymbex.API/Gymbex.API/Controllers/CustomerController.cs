﻿using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Customers;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Gymbex.Application.Security;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IQueryHandler<GetCustomers, IEnumerable<CustomerDto>> _getCustomersQueryHandler;
        private readonly ICommandHandler<SignIn> _signInCommandHandler;
        private readonly ITokenStorage _tokenStorage;

        public CustomerController(ICommandHandler<SignUp> signUpCommandHandler, ICommandHandler<DeleteCustomer> deleteCustomerCommandHandler, IQueryHandler<GetCustomer, CustomerDto> getCustomerByIdQueryHandler, IQueryHandler<GetCustomers, IEnumerable<CustomerDto>> getCustomersQueryHandler, ICommandHandler<SignIn> signInCommandHandler, ITokenStorage tokenStorage)
        {
            _signUpCommandHandler = signUpCommandHandler;
            _deleteCustomerCommandHandler = deleteCustomerCommandHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            _getCustomersQueryHandler = getCustomersQueryHandler;
            _signInCommandHandler = signInCommandHandler;
            _tokenStorage = tokenStorage;
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
        public async Task<ActionResult> Post([FromBody] SignUp command)
        {
            command = command with { CustomerId = Guid.NewGuid() };
            await _signUpCommandHandler.HandlerExecuteAsync(command);
            return Ok();
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<JwtDto>> Post([FromBody] SignIn command)
        {
            await _signInCommandHandler.HandlerExecuteAsync(command);
            var jwt = _tokenStorage.GetJwt();
            return Ok(jwt);
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
