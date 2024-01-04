using Core.Services.Health;
using HealthChecker.Configurations;

namespace HealthChecker.Workers
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> Logger;
        private readonly ServiceProvider ServiceProvider;

        public Worker(ILogger<Worker> logger, ServiceProvider serviceProvider) =>
            (Logger, ServiceProvider) = (logger, serviceProvider);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await using (var scope = ServiceProvider.CreateAsyncScope())
                {
                    Logger.LogInformation("[HEALTH CHECKING START]: {time}", DateTimeOffset.Now);
                    HealthService service = scope.ServiceProvider.GetRequiredService<HealthService>();

                    await HealthJob.Create(service).Start();
                    
                    Logger.LogInformation("[HEALTH CHECKING FINISHED]: {time}", DateTimeOffset.Now);
                    await Task.Delay(WorkerConfiguration.POLLING_INTERVAL_IN_MILLISECONDS, stoppingToken);
                }
            }
        }
    }
}