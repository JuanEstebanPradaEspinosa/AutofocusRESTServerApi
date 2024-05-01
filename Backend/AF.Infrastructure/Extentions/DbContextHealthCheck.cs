using AF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Infrastructure.Extentions
{
    public class DbContextHealthCheck<TContext> : IHealthCheck where TContext : AppDbContext {

        private readonly TContext _context;
        public DbContextHealthCheck(TContext context) {
            _context = context; ;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) {
            try {
                // Perform a test query or operation on your DbContext
                // For example, you can execute a simple query like this:
                await _context.Database.CanConnectAsync(cancellationToken);

                // DbContext is healthy
                return HealthCheckResult.Healthy();
            } catch (Exception ex) {
                // If an exception is thrown, return an unhealthy result with the error details
                return HealthCheckResult.Unhealthy("DbContext connection test failed", ex);
            }
        }
    }
}
