using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.CategoryEquipments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymbex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentCategoriesController(
        IQueryHandler<GetEquipmentCategories, IEnumerable<CategoryEquipmentDto>> getEquipmentCategoriesDto
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryEquipmentDto>>> Get([FromQuery] GetEquipmentCategories query)
        {
            var categories = await getEquipmentCategoriesDto.ExecuteHandleAsync(query);
            if (!categories.Any())
            {
                return NotFound();
            }

            return Ok(categories);
        }
    }
}
