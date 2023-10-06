using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Activities;
using Gymbex.Core.Repositories;
using Gymbex.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    internal sealed class GetActivitiesHandler : IQueryHandler<GetActivities, IEnumerable<ActivityDto>>
    {
        private readonly GymbexDbContext _dbContext;

        public GetActivitiesHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<ActivityDto>> ExecuteHandleAsync(GetActivities query)
        {
            var activities = await _dbContext.Activities.ToListAsync();
            return activities.Select(x => x.AsActivityDto());
        }
    }
}
