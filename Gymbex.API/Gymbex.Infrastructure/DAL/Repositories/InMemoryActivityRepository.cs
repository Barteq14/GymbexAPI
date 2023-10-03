using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Core.Entities;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;
using Gymbex.Infrastructure.DAL.Exceptions;

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
        public Task CreateActivityAsync(Activity activity)
        {
            _activities.Add(activity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return _activities;
        }

        public async Task<Activity> GetActivityByIdAsync(ActivityId id)
        {
            var activity = _activities.SingleOrDefault(x => x.Id == id);
            return activity;
        }

        public Task DeleteActivityByIdAsync(ActivityId id)
        {
            _activities.RemoveAll(x => x.Id == id);
            return Task.CompletedTask;
        }

        public Task ChangeActivityDate(Guid id, Date date)
        {
            var activity = _activities.SingleOrDefault(x => x.Id == new ActivityId(id));
            if (activity is null)
            {
                throw new ActivityNotFoundException(id);
            }

            activity.ChangeActivityDate(date);
            return Task.CompletedTask;
        }
    }
}
