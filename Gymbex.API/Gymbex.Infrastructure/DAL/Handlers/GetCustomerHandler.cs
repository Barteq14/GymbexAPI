using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        private readonly GymbexDbContext _context;

        public GetCustomerHandler(GymbexDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto> ExecuteHandleAsync(GetCustomer query)
        {
            var customer = await _context.Customers
                .Include(x => x.Reservations)
                .Include(x => x.Ticket)
                .SingleOrDefaultAsync(x => x.Id == query.Id);
            return customer.AsCustomerDto();
        }
    }
}
