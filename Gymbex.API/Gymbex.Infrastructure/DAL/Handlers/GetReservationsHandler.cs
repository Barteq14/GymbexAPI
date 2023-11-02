using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Customers;
using Gymbex.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    internal class GetReservationsHandler : IQueryHandler<GetReservations, List<ReservationDto>>
    {
        private readonly GymbexDbContext _dbContext;

        public GetReservationsHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReservationDto>> ExecuteHandleAsync(GetReservations query)
        {
            var list = await _dbContext.Reservations
                .Include(x => x.Activity)
                .Include(x => x.Customer)
                .ToListAsync();

            if (!list.Any())
            {
                throw new ReservationsNotFound();
            }

            return list.Select(x => x.AsReservationDto(x.Activity)).ToList();
        }
    }
}
