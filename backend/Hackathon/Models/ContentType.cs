﻿namespace Hackathon.Models
{
    public class ContentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<EducationalMaterial> EducationalMaterials { get; set; } = null!;
    }
}
