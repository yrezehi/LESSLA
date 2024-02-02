using Core.Models.Health;
using Core.Services.Health;
using Core.Utils;
using HealthChecker.Configurations;

namespace HealthChecker.Workers
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> Logger;
        private readonly IServiceProvider ServiceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider) =>
            (Logger, ServiceProvider) = (logger, serviceProvider);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await using (var scope = ServiceProvider.CreateAsyncScope())
                {
                    Logger.LogInformation("[HEALTH CHECKING START]: {time}", DateTimeOffset.Now);
                    HealthService applicationService = scope.ServiceProvider.GetRequiredService<HealthService>();
                    HealthLogService logService = scope.ServiceProvider.GetRequiredService<HealthLogService>();

                    var applications = await applicationService.GetAll();

                    foreach(var application in applications)
                    {
                        var isReachable = HTTPUtils.IsPingable(application.URL);

                        await logService.Create(HealthCheckLog.Create(application.Id, isReachable));
                    }

                    Console.WriteLine(applications.Select(application => application.ApplicationName));
                    
                    Logger.LogInformation("[HEALTH CHECKING FINISHED]: {time}", DateTimeOffset.Now);
                    await Task.Delay(WorkerConfiguration.POLLING_INTERVAL_IN_MILLISECONDS, stoppingToken);
                }
            }
        }
    }
}