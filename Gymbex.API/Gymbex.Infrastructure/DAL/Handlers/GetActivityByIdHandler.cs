using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Gymbex.Infrastructure.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetActivityByIdHandler: IQueryHandler<GetActivityById,ActivityDto>
    {
        private readonly GymbexDbContext _dbContext;

        public GetActivityByIdHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActivityDto> ExecuteHandleAsync(GetActivityById query)
        {
            var activity = await _dbContext.Activities.SingleOrDefaultAsync(x => x.Id == new ActivityId(query.Id));
            return activity.AsActivityDto();
        }
    }
}
