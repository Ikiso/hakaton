using Hackathon.Models;

namespace Hackathon.Dtos
{
    public class EducationalMaterialEdit
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!; // Ссылка на видео либо ссылка на файл

        public int CourseId { get; set; }
        public bool IsPublic { get; set; }
        public int ContentTypeId { get; set; }
    }

    public record class EducationalMaterialGet(int id);
    public record class EducationalMaterialDto(int Id, string Content, int CourseId, bool IsPuplic, int ContentTypeId);
    public record class EducationalMaterialCreate(string Content, int CourseId, bool IsPuplic, int ContentTypeId);
}
