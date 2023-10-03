using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using Gymbex.Application.Queries;
using Gymbex.Core.Repositories;
using Gymbex.Infrastructure.DAL;
using Gymbex.Infrastructure.DAL.Handlers;
using Gymbex.Infrastructure.DAL.Repositories;


namespace Gymbex.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sectionApp = configuration.GetSection("app"); //pobranie sekcji
            services.Configure<AppOptions>(sectionApp); //zbindowanie na AppOptions

            services.AddScoped<IActivityRepository,InMemoryActivityRepository>();

            var infrastructureAssembly = typeof(AppOptions).Assembly;

            services.Scan(s => s.FromAssemblies(infrastructureAssembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddPostgres(configuration);

            return services;
        }
    }
}
