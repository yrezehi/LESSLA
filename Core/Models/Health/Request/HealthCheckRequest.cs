namespace Core.Models.Health
{
    internal class HealthCheckRequest
    {
        public string Status { get; set; }
        public HealthCheckRequestReport { get; set; }
    }
}
