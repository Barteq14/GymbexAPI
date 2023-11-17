using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.DAL.Repositories
{
    public sealed class PostgresReservationRepository(GymbexDbContext dbContext) : IReservationRepository
    {
        public async Task<Reservation> GetAsync(Guid id)
            => await dbContext.Reservations
            .Include(x => x.Customer)    
            .SingleOrDefaultAsync(x => x.Id == new ReservationId(id));

        public async Task RemoveAsync(Reservation reservation)
        {
            dbContext.Reservations.Remove(reservation);
            await dbContext.SaveChangesAsync();
        }
    }
}
