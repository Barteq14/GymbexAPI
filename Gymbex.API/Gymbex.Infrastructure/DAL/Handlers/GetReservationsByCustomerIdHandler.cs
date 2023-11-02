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
    internal class GetReservationsByCustomerIdHandler : IQueryHandler<GetReservationsByCustomerId, List<ReservationDto>>
    {
        private readonly GymbexDbContext _dbContext;

        public GetReservationsByCustomerIdHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReservationDto>> ExecuteHandleAsync(GetReservationsByCustomerId query)
        {
            var customerId = new CustomerId(query.CustomerId);
            var list  = await _dbContext.Reservations
                .Include(x => x.Activity)
                .Include(x => x.CustomerId)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();

            return list.Select(x => x.AsReservationDto(x.Activity)).ToList();
        }
    }
}
