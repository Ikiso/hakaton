namespace Hackathon.Dtos
{
    public class LongOrganizationDto
    {
        public int Id { get; set; }
        public string INN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public string? Target { get; set; } // цель
        public string? Mission { get; set; } // миссия
        public string Tariff { get; set; } = null!;
    }
}
