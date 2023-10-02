using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Infrastructure.DAL.Repositories
{
    public sealed class InMemoryActivityRepository : IActivityRepository
    {
        public static List<Activity> _activities = new()
        {
            new Activity(Guid.NewGuid(),"Fitness",new DateTime(2023,10,22)),
            new Activity(Guid.NewGuid(),"Yoga",new DateTime(2023,10,14)),
            new Activity(Guid.NewGuid(),"Cross fit",new DateTime(2023,10,11)),
            new Activity(Guid.NewGuid(),"Gym",new DateTime(2023,10,23)),
            new Activity(Guid.NewGuid(),"Gymnastic",new DateTime(2023,10,27)),
        };
        public Task CreateActivity(Activity activity)
        {
            _activities.Add(activity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return _activities;
        }
    }
}
