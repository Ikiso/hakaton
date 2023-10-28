namespace Hackathon.Models
{
    public class EducationalMaterial
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!; // Ссылка на видео либо ссылка на файл

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public bool IsPublic { get; set; }
        public int ContentTypeId { get; set; }
        public ContentType ContentType { get; set; } = null!;

    }
}
