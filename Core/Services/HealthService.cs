using Core.Models.Health;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services
{
    public class HealthService : ServiceBase<HealthCheckRegistry>
    {
        public HealthService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
