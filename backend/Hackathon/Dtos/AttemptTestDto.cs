namespace Hackathon.Dtos
{
    public class AttemptTestDto
    {
        public int TestId { get; set; }
        public List<int> SelectedOptions { get; set; } = new();
    }
}
