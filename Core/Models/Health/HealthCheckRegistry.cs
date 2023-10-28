using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_registry")]
    public class HealthCheckRegistry
    {
        public string ApplicationName { get; set; }
        public int MinutesInterval { get; set; } = 60;
        public string URL { get; set; }
    }
}
