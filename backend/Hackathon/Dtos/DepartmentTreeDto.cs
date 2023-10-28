namespace Hackathon.Dtos
{
    public class DepartmentTreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<DepartmentTreeDto> ChildDepartment { get; set; } = new();
    }
}
