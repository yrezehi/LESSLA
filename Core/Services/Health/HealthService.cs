using Core.Models.Health;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services.Health
{
    public class HealthService : ServiceBase<HealthCheckApplication>
    {
        public HealthService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
