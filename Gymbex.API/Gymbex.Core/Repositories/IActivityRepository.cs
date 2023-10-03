using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Core.Repositories
{
    public interface IActivityRepository
    {
        Task CreateActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();
        Task<Activity> GetActivityByIdAsync(ActivityId id);
        Task DeleteActivityByIdAsync(ActivityId id);
        Task ChangeActivityDate(Guid id, Date date);
    }
}
