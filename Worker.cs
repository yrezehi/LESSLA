using SeqNotification.Services;

namespace SeqNotification
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ReportGenerator reportGenerator;

        public Worker(ILogger<Worker> logger, ReportGenerator _reportGenerator)
        {
            _logger = logger;
            reportGenerator = _reportGenerator;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await reportGenerator.Generate();

                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
        }
    }
}