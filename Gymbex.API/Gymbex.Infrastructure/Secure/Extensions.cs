using Gymbex.Application.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;

namespace Gymbex.Infrastructure.Secure
{
    public static class Extensions
    {
        public static IServiceCollection AddSecure(this IServiceCollection services)
        {
            services
                .AddScoped<IPasswordManager, PasswordManager>()
                .AddScoped<IPasswordHasher<Customer>, PasswordHasher<Customer>>();
            return services;
        }
    }
}
