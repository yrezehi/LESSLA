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
        [Column("description")]
        public string APIKey { get; set; }
    }
}
