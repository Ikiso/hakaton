namespace Hackathon.Models
{
    public class PassedTests
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public int AttemptNumber { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; } = null!;
        public double CompletionPercent { get; set; }
        public bool IsOver { get; set; }
        public List<Answer> Answers { get; set; } = new();
    }
}
