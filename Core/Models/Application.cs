using Core.Models.Abstracts.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("application")]
    public class Application : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("api_key")]
        public string APIKey { get; set; }
        [Column("enable_health_check")]
        public bool EnableHealthCheack { get; set; } = true;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Application(string name, string description) =>
            (Name, Description) = (name, description);

        public static Application Create(string name, string description) =>
            new Application(name, description);

        public Application WithId(int id)
        {
            Id = id;
            return this;
        }
    }
}
