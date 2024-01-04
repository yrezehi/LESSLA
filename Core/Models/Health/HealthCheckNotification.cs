using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_check_notification")]
    public class HealthCheckNotification
    {
        public string Email { get; set; }
    }
}
