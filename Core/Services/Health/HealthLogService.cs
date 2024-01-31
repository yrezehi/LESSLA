using Core.Models.Health;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services.Health
{
    public class HealthLogService : ServiceBase<HealthCheckLog>
    {
        private readonly HealthService HealthService;

        public HealthLogService(IUnitOfWork unitOfWork, HealthService healthService) : base(unitOfWork) =>
            (HealthService) = (healthService);

        public async Task<HealthCheckLogDashboard> Dashboard() =>
            HealthCheckLogDashboard.Create()
                .WithRegistredApplications(await HealthService.Count());
    }
}
