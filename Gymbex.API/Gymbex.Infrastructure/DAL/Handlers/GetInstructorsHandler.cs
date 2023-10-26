using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetInstructorsHandler : IQueryHandler<GetInstructors, List<CustomerDto>>
    {
        private readonly GymbexDbContext _dbContext;

        public GetInstructorsHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerDto>> ExecuteHandleAsync(GetInstructors query)
        {
            var instructorRole = Role.Instructor();

            var instructors =  await _dbContext.Customers
                .Where(x => x.Role == instructorRole).ToListAsync();

            return instructors.Select(x => x.AsCustomerDto()).ToList();
        }
    }
}
