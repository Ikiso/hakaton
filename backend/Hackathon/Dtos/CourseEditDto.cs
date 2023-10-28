namespace Hackathon.Dtos
{
    public class CourseEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
    }
    public record class CourseDto(int Id, string Name, string? Description, int DepartmentId);
}
