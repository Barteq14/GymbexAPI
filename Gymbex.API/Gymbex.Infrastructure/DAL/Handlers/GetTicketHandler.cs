using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries.Tickets;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetTicketHandler : IQueryHandler<GetTicket, TicketDto>
    {
        private readonly GymbexDbContext _dbContext;

        public GetTicketHandler(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketDto> ExecuteHandleAsync(GetTicket query)
        {
            var ticket = await _dbContext.Tickets
                .Include(x => x.Customers)
                .SingleOrDefaultAsync(x => x.Id == new TicketId(query.Id));
            if (ticket is null)
            {
                throw new TicketNotFoundException(query.Id);
            }

            return ticket.AsTicketDto();
        }
    }
}
