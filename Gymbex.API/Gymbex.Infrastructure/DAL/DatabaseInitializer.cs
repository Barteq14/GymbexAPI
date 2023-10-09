using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.Enums;
using Gymbex.Core.Enums.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gymbex.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GymbexDbContext>();
                dbContext.Database.Migrate();

                var tickets = dbContext.Tickets.ToList();
                if (!tickets.Any())
                {
                    tickets = new List<Ticket>()
                    {
                        new Ticket(Guid.NewGuid(), TicketKindEnum.OneDay, TicketKindEnum.OneDay.GetDisplayName()),
                        new Ticket(Guid.NewGuid(), TicketKindEnum.Month, TicketKindEnum.Month.GetDisplayName()),
                        new Ticket(Guid.NewGuid(), TicketKindEnum.HalfYear, TicketKindEnum.HalfYear.GetDisplayName()),
                        new Ticket(Guid.NewGuid(), TicketKindEnum.Year, TicketKindEnum.Year.GetDisplayName()),
                    };

                    dbContext.Tickets.AddRange(tickets);
                    dbContext.SaveChanges();
                }
                return Task.CompletedTask;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
