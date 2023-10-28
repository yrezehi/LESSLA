namespace Core.Models.Health.Request
{
    internal class HealthCheckRequest
    {
        public string Status { get; set; }
        public HealthCheckRequestReport Report { get; set; }
    }
}
