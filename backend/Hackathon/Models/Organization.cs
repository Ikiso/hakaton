namespace Hackathon.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Inn { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public string? Goal { get; set; }
        public string? Mission { get; set; }

        public int TariffId { get; set; }
        public Tariff Tariff { get; set; } = null!;
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
        public List<Department> Departments { get; set; } = new();
    }
}
