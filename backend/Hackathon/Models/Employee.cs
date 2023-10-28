namespace Hackathon.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Post { get; set; }  // Должность 

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public List<PassedTests> PassedTests { get; set; } = new();
    }
}
