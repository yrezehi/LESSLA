using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_logs")]
    public class HealthCheckLog
    {
        [Key]
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

        public HealthCheckLog(int applicationId, bool isHealth) =>
            (ApplicationId, IsHealthy, ExecutionTime, ExecutionDuration) = (applicationId, isHealth, DateTime.Now, 0);

        public static HealthCheckLog Create(int applicationId, bool isHealthy) =>
            new HealthCheckLog(applicationId, isHealthy);
    }
}
