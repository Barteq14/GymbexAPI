using Gymbex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket> GetAsync(TicketId id);
        Task CreateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
    }
}
