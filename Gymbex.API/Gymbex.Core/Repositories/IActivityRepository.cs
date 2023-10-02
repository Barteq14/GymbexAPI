using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;

namespace Gymbex.Core.Repositories
{
    public interface IActivityRepository
    {
        Task CreateActivity(Activity activity);
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();
    }
}
