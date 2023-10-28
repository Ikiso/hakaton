namespace Hackathon.Dtos
{
    public class OrganizationAddDto
    {
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Email { get; set; } = null!;
        public string INN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public string? Target { get; set; } // цель
        public string? Mission { get; set; } // миссия
        public int IdTariff { get; set; }

    }
}
