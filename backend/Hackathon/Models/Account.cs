namespace Hackathon.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
