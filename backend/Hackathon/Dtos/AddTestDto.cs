namespace Hackathon.Dtos
{
    public class AddTestDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CourseId { get; set; }

        public List<QuestionAddDto> Questions { get; set; } = new();


    }

    public class QuestionAddDto
    {
        public int Points { get; set; }
        public string Content { get; set; } = null!;
        public List<OptionAddDto> Options { get; set; } = new();
    }

    public record class OptionAddDto(int Id, string Name, bool IsCorrect);
}
