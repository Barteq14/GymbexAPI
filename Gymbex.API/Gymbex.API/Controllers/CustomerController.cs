using Gymbex.Application.Abstractions;
using Gymbex.Application.Commands.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpCommandHandler;

        public CustomerController(ICommandHandler<SignUp> signUpCommandHandler)
        {
            _signUpCommandHandler = signUpCommandHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignUp command)
        {
            command = command with { CustomerId = Guid.NewGuid() };
            await _signUpCommandHandler.HandlerExecuteAsync(command);
            return Ok();
        }
    }
}
