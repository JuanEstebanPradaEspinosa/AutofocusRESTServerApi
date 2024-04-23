using AF.Application;
using AF.Application.Mapper;
using AF.Infrastructure.Data;
using AF.Infrastructure.DependencyInjection;
using AF.Infrastructure.HealthChecks;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the containers
// Adding automapper
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers();
builder.Services.AddHealthChecks().AddCheck<DbContextHealthCheck<AppDbContext>>("CustomHealthCheck");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger => {
    // This is to generate the Default UI of Swagger Documantation
    swagger.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v3.1",
        Title = "AutoFocus Web API",
        Description = "Authentication with JWT - Clean Architacture template(ish?) Created by Juan & Luca + " +
        "README moet nog gemaakt worden voor nuttige informatie..."
    });
    // To enable Authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
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


builder.Services.InfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
