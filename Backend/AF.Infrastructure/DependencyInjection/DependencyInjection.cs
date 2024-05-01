using AF.Domain.Interfaces;
using AF.Infrastructure.Data;
using AF.Infrastructure.Repos;
using AF.Domain.Entities;
using AF.Application.Contracts;
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
using AF.Application;
using AF.Domain.Pagination;

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
            
            // Adding Identity Service -- don't know how?
/*            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true; // if you want to verify using an email
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();

*/
            //Health Checks
            services
                .AddHealthChecks()
                .AddDbContextCheck<AppDbContext>("DbContextHealthCheck");

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.DisableDatabaseMigrations();
                //setup.SetEvaluationTimeInSeconds(5); // Configures the UI to poll for health checks updates every 5 seconds
                //setup.SetApiMaxActiveRequests(1); //Only one active request will be executed at a time. All the excedent requests will result in 429 (Too many requests)
                setup.MaximumHistoryEntriesPerEndpoint(50); // Set the maximum history entries by endpoint that will be served by the UI api middleware
                //setup.SetNotifyUnHealthyOneTimeUntilChange(); // You will only receive one failure notification until the status changes

                setup.AddHealthCheckEndpoint("EFCore connection", "/working");

            }).AddInMemoryStorage();
            //Add Here all security where needed and logging etc....


            /*            
             *JwtBearer Nuget Package -

              Dit stuk code configureert JWT(JSON Web Token) authenticatie voor het ASP.NET Core framework.
              Hetgebruikt de JwtBearer NuGet package en stelt de validatieparameters in voor het token, zoals issuer,
              audience, en de bijbehorende sleutel.
            */

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {

                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

            services.AddAuthorization();

            /*Zonder deze scopes* zouden ze altijd een 500 error status code krijgen*/
            // * AddScoped zorgt voor data in en uit de databank te halen binnen een sessie van de applicatie

            //Contract with jwt!!!!
            services.AddScoped <IUser, UserRepository>();
            services.AddScoped<ISortHelper<Car>, SortHelper<Car>>();
            //GenericRepositories
            #region Repositories
            // * AddTransient: 
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion

            //Adding manager in here with the correct repositories
            services.AddScoped<Manager>();

            return services;
        }
    }
}
