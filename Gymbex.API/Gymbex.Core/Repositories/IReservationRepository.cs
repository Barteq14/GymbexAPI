using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetAsync(ReservationId id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task AddAsync(Reservation reservation);
        Task DeleteAsync(Reservation reservation);
    }
}
