namespace Hackathon.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Points { get; set; } // За верный ответ

        public int TestId { get; set; }
        public Test Test { get; set; } = null!;
        public List<Option> Options { get; set; } = new();
    }
}
