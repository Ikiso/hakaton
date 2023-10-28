namespace Hackathon.Dtos
{
    public class TestGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<QuestionGetDto> Questions { get; set; } = new();
    }

    public class QuestionGetDto
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string Content { get; set; } = null!;
        public List<OptionGetDto> Options { get; set; } = new();

    }

    public record class OptionGetDto(int Id, string Name, bool IsCorrect);
}
