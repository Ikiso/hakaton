namespace Hackathon.Dtos
{
    public class LoginManyOrganization
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int EmployeeId { get; set; }
    }
}
