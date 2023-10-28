namespace Hackathon.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public List<Answer> Answers { get; set; } = new();
    }
}
