namespace HealthChecker.Workers
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> Logger;

        public Worker(ILogger<Worker> logger) =>
            Logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}