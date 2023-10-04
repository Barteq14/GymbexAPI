using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Core.Entities;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    public static class Extensions
    {
        public static ActivityDto AsActivityDto(this Activity activity)
        {
            return activity is not null ? new ActivityDto()
            {
                Id = activity.Id,
                Name = activity.Name,
                Date = activity.Date
            } : null;
        }
    }
}
