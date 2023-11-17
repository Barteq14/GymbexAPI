using Gymbex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetAsync(Guid id);
        Task RemoveAsync(Reservation reservation);
    }
}
