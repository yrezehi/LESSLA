using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Chicken
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        
        public Chicken(string username) =>
            (Username, Email) = (username, Chicken.StripUsername(username));

        private static string StripUsername(string email) =>
            email.Split('@')[0];
    }
}
