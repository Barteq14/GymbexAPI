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
    public sealed class PostgresReservationRepository : IReservationRepository
    {
        private readonly GymbexDbContext _dbContext;

        public PostgresReservationRepository(GymbexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> GetAsync(ReservationId id)
            => await _dbContext.Reservations.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Reservation>> GetAllAsync()
            => await _dbContext.Reservations.ToListAsync();

        public async Task AddAsync(Reservation reservation)
        {
            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();    
        }
    }
}
