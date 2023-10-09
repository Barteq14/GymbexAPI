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
using Gymbex.Application.Security;
using Gymbex.Core.Repositories;
using Gymbex.Infrastructure.Auth;
using Gymbex.Infrastructure.DAL;
using Gymbex.Infrastructure.DAL.Handlers;
using Gymbex.Infrastructure.DAL.Repositories;
using Gymbex.Infrastructure.Exceptions;
using Gymbex.Infrastructure.Secure;


namespace Gymbex.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sectionApp = configuration.GetSection("app"); //pobranie sekcji
            services.Configure<AppOptions>(sectionApp); //zbindowanie na AppOptions

            services.AddScoped<IActivityRepository,PostgresActivityRepository>();
            services.AddScoped<ICustomerRepository,PostgresCustomerRepository>();
            services.AddSingleton<ExceptionMiddleware>();
            services.AddHttpContextAccessor();
            services.AddAuth(configuration);
            services.AddSecure();

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
