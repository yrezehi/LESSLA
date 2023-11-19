using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("application")]
    public class Application
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("api_key")]
        public string APIKey { get; set; }
        [Column("enable_health_check")]
        public string EnableHealthCheack{ get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
