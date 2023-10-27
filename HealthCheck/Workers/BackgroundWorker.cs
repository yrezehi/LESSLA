using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthCheck.Workers
{
    public class Worker : BackgroundService
    {
        public HttpClient HttpClient;
        public ILogger<Worker> Logger;

        public Worker(ILogger<Worker> logger) =>
            (Logger) = (logger);

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Logger.LogInformation($"{nameof(Worker)}: {"JOB STARTED"} AT {DateTime.Now}");

                await Task.Delay(1000, cancellationToken);
                Logger.LogInformation($"{nameof(Worker)}: {"JOB ENDED"} AT {DateTime.Now}");
            }
        }
    }
}
