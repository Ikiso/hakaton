namespace Hackathon.Dtos
{
    public class RegistrationResultDto
    {
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool IsNewUser { get; set; }
    }
}
