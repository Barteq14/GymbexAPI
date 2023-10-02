using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace Gymbex.Infrastructure.DAL.Handlers
{
    internal sealed class GetActivitiesHandler : IQueryHandler<GetActivities, IEnumerable<ActivityDto>>
    {
        //private readonly GymbexDbContext _context;

        //public GetActivitiesHandler(GymbexDbContext context)
        //{
        //    _context = context;
        //}

        public static List<ActivityDto> _activities = new()
        {
            new ActivityDto()
            {
                Id = Guid.NewGuid(),
                Name = "Fitness",
                Date = DateTime.Now,
                Customers = new List<CustomerDto>()
                {
                    new CustomerDto()
                    {
                        Id = Guid.NewGuid(),
                        Email = "bb.bbb@gymbex.io",
                        FullName = "barbara bogacz",
                        PhoneNumber = "2131312312312"
                    },
                    new CustomerDto()
                    {
                        Id = Guid.NewGuid(),
                        Email = "gg.ggg@gymbex.io",
                        FullName = "Grzegorz gietek",
                        PhoneNumber = "112313123313"
                    }
                }
            },
            new ActivityDto()
            {
                Id = Guid.NewGuid(),
                Name = "Zumba",
                Date = DateTime.Now,
                Customers = new List<CustomerDto>()
                {
                    new CustomerDto()
                    {
                        Id = Guid.NewGuid(),
                        Email = "ww.vvvv@gymbex.io",
                        FullName = "waldek vito",
                        PhoneNumber = "75473734734737"
                    },
                    new CustomerDto()
                    {
                        Id = Guid.NewGuid(),
                        Email = "qqqq.eeee@gymbex.io",
                        FullName = "queuqe etyk",
                        PhoneNumber = "555343423234"
                    }
                }
            }
        };


        public async Task<IEnumerable<ActivityDto>> ExecuteHandleAsync(GetActivities query)
        {
            //var activityDtos = await _context.Activities
            //    .Include(x => x.Customers)
            //    .Select(x => new ActivityDto()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Date = x.Date,
            //    Customers = x.Customers.Select(z => new CustomerDto()
            //    {
            //        Id = z.Id,
            //        Email = z.Email,
            //        FullName = z.Fullname,
            //        PhoneNumber = z.PhoneNumber
            //    })
            //}).ToListAsync();

            return _activities;
        }
    }
}
