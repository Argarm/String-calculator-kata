using System;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StringCalculatorAPI
{
    public class HealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var healthCheckResultHealthy = true;
            string path = @"..\Log.txt";
            var fs = new FileStream(path, FileMode.Open);
            if (fs.CanWrite)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("File exist and you have permission to write on it."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("File dont exist or you dont have permission to write on it."));
        }

    }
}
