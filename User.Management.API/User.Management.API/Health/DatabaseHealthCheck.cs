using Microsoft.Extensions.Diagnostics.HealthChecks;
using User.Management.API.Models;

namespace User.Management.API.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly ApplicationDbContext _context;
        public DatabaseHealthCheck(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _context.Database.CanConnectAsync(cancellationToken);
                return result ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy("Unable to connect to the database.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("An error occurred while checking the database connectivity.", ex);
            }
        }
    }
}
