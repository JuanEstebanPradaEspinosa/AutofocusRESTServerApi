using AF.Application.Contracts;
using AF.Domain.Entities;
using AF.Infrastructure.Data;
using AF.Infrastructure.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

namespace AF.Infrastructure.DependencyInjection {
    public static class DependencyInjection {

        public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            /*
              Dit stuk code voegt Entity Framework Core diensten toe voor gegevensopslag. 
              Het configureert een databasecontext met de opgegeven SQL Server 
              verbindingssnaam en migratie-assembly. 
            */
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("dcs")),
                ServiceLifetime.Scoped);

            /* Health Checks */
            services
                .AddHealthChecks()
                .AddCheck("sql", () => {
                    using (var connection = new SqlConnection(configuration.GetConnectionString("dcs"))) {
                        try {
                            connection.Open();
                        } catch (SqlException) {

                            return HealthCheckResult.Unhealthy();
                        }
                    }

                    return HealthCheckResult.Healthy();
                });

            /* Rate Limiter */
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions {
                            AutoReplenishment = true,
                            PermitLimit = 10,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(1)
                        }));
            });

            /*
             JwtBearer Nuget Package -  

             Dit stuk code configureert JWT (JSON Web Token) authenticatie voor het ASP.NET Core framework.
             Hetgebruikt de JwtBearer NuGet package en stelt de validatieparameters in voor het token, zoals issuer,
             audience, en de bijbehorende sleutel. 
           */
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {

                options.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });


            /*Zonder deze scopes* zouden ze altijd een 500 error status code krijgen*/
            // * AddScoped zorgt voor data in en uit de databank te halen binnen een sessie van de applicatie
            services.AddScoped<IUser, UserRepo>();
            services.AddScoped <IRepository<User>,GenericRepository<User>>();
            services.AddScoped <IRepository<Booking>,GenericRepository<Booking>>();
            services.AddScoped <IRepository<Car>,GenericRepository<Car>>();
            return services;
        }
    }
}
