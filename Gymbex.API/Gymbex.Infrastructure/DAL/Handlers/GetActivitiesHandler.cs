using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    internal sealed class GetActivitiesHandler : IQueryHandler<GetActivities, IEnumerable<ActivityDto>>
    {
        private readonly GymbexDbContext _context;

        public GetActivitiesHandler(GymbexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivityDto>> ExecuteHandleAsync(GetActivities query)
        {
            var activityDtos = await _context.Activities
                .Include(x => x.Customers)
                .Select(x => new ActivityDto()
            {
                Id = x.Id,
                Name = x.Name,
                Date = x.Date,
                Customers = x.Customers.Select(z => new CustomerDto()
                {
                    Id = z.Id,
                    Email = z.Email,
                    FullName = z.Fullname,
                    PhoneNumber = z.PhoneNumber
                })
            }).ToListAsync();

            return activityDtos;
        }
    }
}
