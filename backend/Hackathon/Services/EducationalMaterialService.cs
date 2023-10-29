using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class EducationalMaterialService : IEducationalMaterialService
    {
        private readonly ApplicationDbContext _context;
        public EducationalMaterialService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public EducationalMaterial AddItem(EducationalMaterialCreate materialCreate)
        {
            var material = new EducationalMaterial()
            {
                Content = materialCreate.Content,
                ContentType = _context.ContentTypes.Find(materialCreate.ContentTypeId)!,
                Course = _context.Courses.Find(materialCreate.CourseId)!,
                IsPublic = materialCreate.IsPuplic
            };
            _context.EducationalMaterials.Add(material);
            _context.SaveChanges();
            return material;
        }

        public void DelteItem(EducationalMaterialGet materialGet)
        {
            _context.EducationalMaterials.Remove(_context.EducationalMaterials.Find(materialGet.id)!);
            _context.SaveChanges();
        }

        public EducationalMaterial EditItem(EducationalMaterialEdit materialEdit)
        {
            var material = _context.EducationalMaterials.Find(materialEdit.Id)!;
            material.Content = materialEdit.Content;
            material.ContentType = _context.ContentTypes.Find(materialEdit.ContentTypeId)!;
            material.Course = _context.Courses.Find(materialEdit.CourseId)!;
            material.IsPublic = materialEdit.IsPublic;

            _context.EducationalMaterials.Update(material);
            _context.SaveChanges();
            return material;
        }

        public bool ElementExists(int id)
        {
            return _context.EducationalMaterials.Find(id) != null;
        }

        public List<EducationalMaterialDto> GetAllItemDto(int idCourse)
        {
            var result = new List<EducationalMaterialDto>();
            foreach (var item in _context.EducationalMaterials.Where(a=>a.CourseId == idCourse).Include(a=>a.ContentType).ToList())
            {
                result.Add(new EducationalMaterialDto(item.Id, item.Content, item.CourseId, item.IsPublic,item.ContentType.Name, item.ContentTypeId));
            }
            return result;
        }

        public EducationalMaterial GetItem(EducationalMaterialGet materialGet)
        {
            return _context.EducationalMaterials.Include(a => a.Course).Include(a=>a.ContentType).FirstOrDefault(a=>a.Id == materialGet.id)!;
        }

        public EducationalMaterialDto GetItemDto(EducationalMaterialGet materialGet)
        {
            var material = _context.EducationalMaterials.FirstOrDefault(a=>a.Id == materialGet.id)!;
            var result = new EducationalMaterialDto(material.Id, material.Content, material.CourseId, material.IsPublic, material.ContentType.Name, material.ContentTypeId);
            return result;
        }
    }
}
