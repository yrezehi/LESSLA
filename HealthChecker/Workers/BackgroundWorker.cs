using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthCheck.Workers
{
    public class BackgroundWorker : BackgroundService
    {
        public HttpClient HttpClient;
        public ILogger<BackgroundWorker> Logger;

        public BackgroundWorker(ILogger<BackgroundWorker> logger) =>
            (Logger, HttpClient) = (logger, new HttpClient());

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
