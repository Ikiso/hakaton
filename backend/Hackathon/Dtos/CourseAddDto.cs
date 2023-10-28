namespace Hackathon.Dtos
{
    public class CourseAddDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
    }
}
