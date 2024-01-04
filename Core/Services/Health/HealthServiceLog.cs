using Core.Models.Health;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services.Health
{
    public class HealthServiceLog : ServiceBase<HealthCheckLog>
    {
        public HealthServiceLog(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
