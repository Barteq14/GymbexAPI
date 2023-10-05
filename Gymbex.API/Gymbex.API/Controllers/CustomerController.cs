using Gymbex.Application.Commands.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignUp command)
        {
            command = command with { CustomerId = Guid.NewGuid() };

            return Ok();
        }
    }
}
