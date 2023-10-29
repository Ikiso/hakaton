namespace Hackathon.Dtos
{
    public class PassedTestsGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Percent { get; set; }
        public int AttemptNumber { get; set; }
    }
}
