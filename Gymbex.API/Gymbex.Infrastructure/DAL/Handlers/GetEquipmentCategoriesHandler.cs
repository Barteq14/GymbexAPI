using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.CategoryEquipments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    internal sealed class GetEquipmentCategoriesHandler(GymbexDbContext dbContext) : IQueryHandler<GetEquipmentCategories, IEnumerable<CategoryEquipmentDto>>
    {
        public async Task<IEnumerable<CategoryEquipmentDto>> ExecuteHandleAsync(GetEquipmentCategories query)
            => await dbContext.CategoriesEquipment
                .Select(x => x.AsEquipmentsCategoryDto())
                .ToListAsync();
    }
}
