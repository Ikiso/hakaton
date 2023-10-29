namespace Hackathon.Dtos
{
    public class TestGetItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPassed { get; set; }
        public int? AttemptionNumber { get; set; }
        public int? Percent { get; set; }
    }
}
