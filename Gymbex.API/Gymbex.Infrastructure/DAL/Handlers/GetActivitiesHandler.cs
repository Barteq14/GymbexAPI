using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Gymbex.Core.Repositories;
using Gymbex.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    internal sealed class GetActivitiesHandler : IQueryHandler<GetActivities, IEnumerable<ActivityDto>>
    {
        private readonly IActivityRepository _activityRepository;

        public GetActivitiesHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }


        public async Task<IEnumerable<ActivityDto>> ExecuteHandleAsync(GetActivities query)
        {
            var activities = await _activityRepository.GetAllActivitiesAsync();
            var activitiesDto = activities.Select(x => new ActivityDto()
            {
                Id = x.Id,
                Name = x.Name,
                Date = x.Date
            });
            return activitiesDto;
        }
    }
}
