using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Repositories;
using Gymbex.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gymbex.Infrastructure.DAL
{
    public static class Extensions
    {
        private const string PostgresSection = "postgres";
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(PostgresSection);
            services.Configure<PostgresOption>(section);
            var options = configuration.GetOption<PostgresOption>(PostgresSection);

            services.AddDbContext<GymbexDbContext>(x => x.UseNpgsql(options.ConnectionString));
            services.AddScoped<IActivityRepository, PostgresActivityRepository>();
            services.AddScoped<ICustomerRepository, PostgresCustomerRepository>();
            services.AddScoped<ITicketRepository, PostgresTicketRepository>();
            services.AddScoped<IReservationRepository, PostgresReservationRepository>();
            services.AddHostedService<DatabaseInitializer>();

            return services;
        }

        public static T GetOption<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
