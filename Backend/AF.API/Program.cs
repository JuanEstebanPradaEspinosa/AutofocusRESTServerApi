using AF.Application.Mapper;
using AF.Infrastructure.DependencyInjection;
using HealthChecks.UI.Client;
using IdentityModel.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Threading.RateLimiting;

//Security Headers collection
var policyCollection = new HeaderPolicyCollection()
    /*
     * X-Frame-Options: Deny - only applied to "document" responses
     * X-XSS-Protection: 1; mode=block - only applied to "document" responses
     * X-Content-Type-Options: nosniff
     * Referrer-Policy: strict-origin-when-cross-origin - only applied to "document" responses
     * Content-Security-Policy: object-src 'none'; form-action 'self'; frame-ancestors 'none'
     * Strict-Transport-Security: max-age=31536000; includeSubDomains - only applied to HTTPS response *    HSTS protocol die samenwerk met HTPPS
     */
    .AddDefaultSecurityHeaders()
    //Change the HSTS to have Preload with it
    .AddStrictTransportSecurityMaxAgeIncludeSubDomainsAndPreload()
    .AddPermissionsPolicy(builder =>
    {
        builder.AddAccelerometer().None();
        builder.AddCamera().None();
        builder.AddGeolocation().None();
        builder.AddGyroscope().None();
        builder.AddMagnetometer().None();
        builder.AddMicrophone().None();
        builder.AddPayment().None();
        builder.AddUsb().None();
    })
    .AddCustomHeader("X-Permitted-Cross-Domain-Policies", "none");


var builder = WebApplication.CreateBuilder(args);

//Forward headers configuration for reverse procy
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

//1. Cors Middleware
// Adding cors for React client to connect with the rest api server safely
// Voor REACT client toegevoegd:
{
    Console.WriteLine("Cors active");
    // Adding CORS Policy
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
        });
    });
}

// 2. Rate Limiter
//Rate Limiter - simple form van rate limiter voor onze project... extra Request bij authenticeerd gebruikers
// meer request te kunnen laten sturen door gebruik te maken van een aangepaste policy! 
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.CreateChained(
        PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(), partition =>
                new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 600,
                    Window = TimeSpan.FromMinutes(1)
                })),
        PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(), partition =>
                new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 6000,
                    Window = TimeSpan.FromHours(1)
                })));

    //add Onreject for more information and goed for the logger bij rejecten van request!
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
               $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s).", cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
               "Too many requests. Please try again later.", cancellationToken: token);
        }
    };

});

// Add services to the containers
builder.Services.AddAutoMapper(typeof(MappingConfig)); //Adding automapper
builder.Services.AddControllers();

//For adding the rest for te Dependecy injection in the infrastructure - healtchecker - dbcontext connections - Identity - Repository services
builder.Services.InfrastructureServices(builder.Configuration);

//Add Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger => {
    // This is to generate the Default UI of Swagger Documantation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v3.1",
        Title = "AutoFocus Web API",
        Description = "Authentication with JWT - Clean Architacture template(ish?) Created by Juan & Luca + " +
        "README moet nog gemaakt worden voor nuttige informatie..."
    });
    // To enable Authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, Array.Empty<string>()
        }
    });
});

// For full control - SecurityHeaders - the code ensures that the anti-forgery token is generated securely and provides protection against CSRF attacks
builder.Services.AddAntiforgery(options =>
{
    options.SuppressXFrameOptionsHeader = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use Cors For React client:
app.UseCors("AllowOrigin");

// Use Ratelimiter
app.UseRateLimiter();

// USe Healthcheck service - default
app.UseHealthChecks("/working", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// Use Middelware package to control the security headers - have to be before the any endpoints
app.UseSecurityHeaders(policyCollection);

//url /healtchecks-ui - with ui package
app.UseRouting().UseEndpoints(config =>
{
    config.MapHealthChecksUI();
});

if (!app.Environment.IsDevelopment()) // enkel in PRODUCTIE:
{
    app.UseHsts(); // Use it in the security header? Or manuel? like here? Can this be removed?
    app.UseHttpsRedirection();
}
// for vertification and autorisation - with the JWT token
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
