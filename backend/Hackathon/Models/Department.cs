namespace Hackathon.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Department> ChildDepartment { get; set; } = new();

        public List<Employee> Employees = new();

        public List<Course> Courses { get; set; } = new();
        public Organization Organization { get; set; } = null!;
        public int OrganizationId { get; set; }
    }
}
