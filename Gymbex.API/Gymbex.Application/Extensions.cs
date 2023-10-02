using Gymbex.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Gymbex.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            //var applicationAssembly = typeof(ICommandHandler<>).Assembly;

            ////zarejestrowanie modułów dynamicznie
            //services.Scan(s => s.FromAssemblies(applicationAssembly)
            //    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());

            return services;
        }
    }
}
