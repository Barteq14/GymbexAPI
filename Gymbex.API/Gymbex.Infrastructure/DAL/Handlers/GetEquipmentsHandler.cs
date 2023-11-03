using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Equipments;
using Gymbex.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetEquipmentsHandler : IQueryHandler<GetEquipments, List<EquipmentDto>>
    {
        private readonly GymbexDbContext _dbContext;

        public GetEquipmentsHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EquipmentDto>> ExecuteHandleAsync(GetEquipments query)
        {
            var list = await _dbContext.Equipments
                .Include(x => x.CategoryEquipment)
                .ToListAsync();

            if (!list.Any())
            {
                throw new EquipmentsNotFoundException();
            }

            return list.Select(x => x.AsEquipmentDto()).ToList();
        }
    }
}
