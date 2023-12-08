using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Security;
using Gymbex.Infrastructure.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Gymbex.Infrastructure.Auth
{
    public static class Extensions
    {
        private static readonly string AuthSectionName = "auth";
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(AuthSectionName);
            services.Configure<AuthOption>(section);

            var options = configuration.GetOption<AuthOption>(AuthSectionName);

            services.AddScoped<IAuthenticator, Authenticatior>();
            services.AddSingleton<ITokenStorage, HttpContextTokenStorage>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Audience = options.Audience;
                    x.IncludeErrorDetails = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = options.Issuer,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
                    };
                })
                .AddCookie(options =>
                {
                    options.Cookie.Name = "TwoFactorCookie";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("is-admin", policy =>
                {
                    policy.RequireRole("Administrator");
                });

                option.AddPolicy("2fa-policy", policy =>
                {
                    policy.RequireClaim("2fa", "true");
                });
            });


            //konfiguracja sesji
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.Cookie.Name = ".MyApp.Session";
                option.IdleTimeout = TimeSpan.FromMinutes(1);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });
    
            return services;
        }
    }
}
