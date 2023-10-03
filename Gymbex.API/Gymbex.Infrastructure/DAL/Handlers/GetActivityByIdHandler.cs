using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Gymbex.Core.Repositories;
using Gymbex.Infrastructure.DAL.Exceptions;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public sealed class GetActivityByIdHandler: IQueryHandler<GetActivityById,ActivityDto>
    {
        private readonly IActivityRepository _activityRepository;


        public GetActivityByIdHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<ActivityDto> ExecuteHandleAsync(GetActivityById query)
        {
            var activity = await _activityRepository.GetActivityByIdAsync(query.Id);
            return activity.AsActivityDto();
        }
    }
}
