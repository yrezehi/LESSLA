using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_logs")]
    public class HealthCheckLog
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("application_id")]
        public int ApplicationId { get; set; }
        [Column("execution_time")]
        public DateTime ExecutionTime { get; set; }
        [Column("execution_duration")]
        public int ExecutionDuration { get; set; }
        [Column("is_healthy")]
        public bool IsHealthy { get; set; }
    }
}
