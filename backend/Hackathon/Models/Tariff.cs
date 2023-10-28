namespace Hackathon.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Decription { get; set; } = null!;
        public int Price { get; set; }
        public int EmployeeLimit { get; set; }

        public List<Organization> Organizations { get; set; } = new();
    }
}
