using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("application")]
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string APIKey { get; set; }
    }
}
