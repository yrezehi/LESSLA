using Core.Models.Abstracts.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_check_notification")]
    public class HealthCheckNotification : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        public string Email { get; set; }
        
        [Column("registry_id")]
        [ForeignKey("HealthRegistry")]
        public int RegistryId { get; set; }

        public HealthCheckRegistry HealthRegistry { get; set; }

        public HealthCheckNotification() { }
    }
}
