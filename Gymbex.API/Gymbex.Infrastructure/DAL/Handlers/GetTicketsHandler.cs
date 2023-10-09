using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetTicketsHandler : IQueryHandler<GetTickets, IEnumerable<TicketDto>>
    {
        private readonly GymbexDbContext _dbContext;

        public GetTicketsHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TicketDto>> ExecuteHandleAsync(GetTickets query)
        {
            var tickets = await _dbContext.Tickets.ToListAsync();
            return tickets.Select(x => x.AsTicketDto());
        }
    }
}
