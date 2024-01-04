using Core.Models.Health;
using Core.Services.Health;

namespace HealthChecker.Workers
{
    public class HealthJob
    {
        public HealthService Service { get; set; }

        public HealthJob(HealthService service) =>
            Service = service;

        public static HealthJob Create(HealthService service) =>
            new HealthJob(service);
        
        public async Task Start()
        {
            IEnumerable<HealthCheckRegistry> registries = await Service.GetAll();

            foreach (HealthCheckRegistry registry in registries)
            {
                
            }
        }
    }
}
