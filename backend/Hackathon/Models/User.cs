namespace Hackathon.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateOnly DateOfBirdh { get; set; }
        public string? TelegramUsername { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public List<Employee> Employees { get; set; } = new();
    }
}
