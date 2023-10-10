using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Repositories
{
    public sealed class PostgresActivityRepository : IActivityRepository
    {
        private readonly GymbexDbContext _context;

        public PostgresActivityRepository(GymbexDbContext context)
        {
            _context = context;
        }


        public async Task CreateActivityAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return await _context.Activities.Include(x => x.Reservations).ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(ActivityId id)
        {
            return await _context.Activities
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Activity> GetActivityByNameAsync(ActivityName name)
        {
            return await _context.Activities.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task DeleteActivityByIdAsync(Activity activity)
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
        }
    }
}
