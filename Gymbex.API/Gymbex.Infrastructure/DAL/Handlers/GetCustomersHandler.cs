using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetCustomersHandler : IQueryHandler<GetCustomers, IEnumerable<CustomerDto>>
    {
        private readonly GymbexDbContext _context;

        public GetCustomersHandler(GymbexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> ExecuteHandleAsync(GetCustomers query) 
            => await _context.Customers.Select(x => x.AsCustomerDto()).ToListAsync();

    }
}
