namespace Hackathon.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<EducationalMaterial> EducationalMaterials { get; set; } = new();
        public List<Test> Tests { get; set; } = new();
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}
