namespace Hackathon.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public List<Question> Questions { get; set; } = new();
        public List<PassedTests> PassedTests { get; set; } = new();
    }
}
