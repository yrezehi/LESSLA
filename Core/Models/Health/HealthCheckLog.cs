namespace Core.Models
{
    public class HealthCheckLog
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int ExecutionDuration { get; set; }
        public bool IsHealthy { get; set; }
    }
}
