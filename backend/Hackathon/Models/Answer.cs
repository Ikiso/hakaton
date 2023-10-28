namespace Hackathon.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int NumberOfAnswer { get; set; }

        public int PassedTestsId { get; set; }
        public PassedTests PassedTests { get; set; } = null!;
        public List<Option> Options { get; set; } = new();
    }
}
