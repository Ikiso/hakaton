namespace Hackathon.Dtos
{
    public class AuthOptionsConfig
    {
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public string Key { get; set; } = String.Empty;
        public bool ValidateLifetime { get; set; }
    }
}
