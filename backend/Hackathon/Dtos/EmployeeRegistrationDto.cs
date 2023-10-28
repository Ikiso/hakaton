namespace Hackathon.Dtos
{
    public class EmployeeRegistrationDto
    {
        public int DepartmentId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Email { get; set; } = null!;
    }
}
