namespace Hackathon.Dtos
{
    public class EditTestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<QuestionEditDto> Questions { get; set; } = new();

    }

    public class QuestionEditDto
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string Content { get; set; } = null!;
        public List<OptionEditDto> Options { get; set; } = new();
    }

    public record class OptionEditDto(int Id,string Name, bool IsCorrect);
}
