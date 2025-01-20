namespace TaskFlowBackend.Models
{
    public class User
    {
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; } // Store plain text password
        public string Email { get; set; } // Property for email
    }
}
