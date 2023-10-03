using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
