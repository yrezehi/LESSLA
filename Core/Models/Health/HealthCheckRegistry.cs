using Core.Models.Abstracts.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_registry")]
    public class HealthCheckRegistry : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("application_name")]
        public string ApplicationName { get; set; }
        [Column("minutes_interval")]
        public int MinutesInterval { get; set; } = 60;
        [Column("url")]
        public string URL { get; set; }

        public HealthCheckRegistry() { }

        public HealthCheckRegistry(string applicationName, string url) =>
            (ApplicationName, URL) = (applicationName, url);

        public static HealthCheckRegistry Create(string applicationName, string url) =>
            new HealthCheckRegistry(applicationName, url);

        public HealthCheckRegistry WithId(int id)
        {
            Id = id;
            return this;
        }
    }
}
