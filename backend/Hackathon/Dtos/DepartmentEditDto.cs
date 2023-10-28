namespace Hackathon.Dtos
{
    public class DepartmentEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
