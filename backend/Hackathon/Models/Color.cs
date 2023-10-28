namespace Hackathon.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Organization> Organizations { get; set; } = new();
    }
}
