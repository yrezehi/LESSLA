namespace Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        
        public User(string username) =>
            (Username, Email) = (username, User.StripUsername(username));

        private static string StripUsername(string email) =>
            email.Split('@')[0];
    }
}
