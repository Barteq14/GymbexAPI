using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Repositories
{
    public sealed class PostgresTicketRepository : ITicketRepository
    {
        private readonly GymbexDbContext _context;

        public PostgresTicketRepository(GymbexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
            => await _context.Tickets.ToListAsync();

        public async Task<Ticket> GetAsync(TicketId id)
            => await _context.Tickets
            .Include(x => x.Customers)
            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
