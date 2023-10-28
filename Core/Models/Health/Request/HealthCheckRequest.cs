using Core.Models.Health.Request;

namespace Core.Models.Health
{
    internal class HealthCheckRequest
    {
        public string Status { get; set; }
        public HealthCheckRequestReport Report { get; set; }
    }
}
