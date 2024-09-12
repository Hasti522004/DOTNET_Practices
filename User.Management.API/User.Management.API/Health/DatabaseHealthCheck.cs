using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;
using User.Management.API.Models;

namespace User.Management.API.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DatabaseHealthCheck> _logger;
        public DatabaseHealthCheck(ApplicationDbContext context, ILogger<DatabaseHealthCheck> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                // Using a more specific query to check the health of the database
                await _context.Database.ExecuteSqlRawAsync("SELECT 1 WHERE EXISTS (SELECT * FROM sys.tables);", cancellationToken);
                return HealthCheckResult.Healthy("Database is responsive.");
            }
            catch (DbException dbEx)
            {
                _logger.LogError(dbEx, "Database health check failed.");
                return HealthCheckResult.Unhealthy("An error occurred while checking the database connectivity.", dbEx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during the health check.");
                return HealthCheckResult.Unhealthy("An unexpected error occurred.", ex);
            }
        }

    }
}
