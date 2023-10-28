using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IEducationalMaterialService
    {
        public EducationalMaterial AddItem(EducationalMaterialCreate materialCreate);
        public EducationalMaterial EditItem(EducationalMaterialEdit materialEdit);
        public void DelteItem(EducationalMaterialGet materialGet);
        public EducationalMaterial GetItem(EducationalMaterialGet materialGet);
        public EducationalMaterialDto GetItemDto(EducationalMaterialGet materialGet);
        public List<EducationalMaterialDto> GetAllItemDto(int idCourse);
        public bool ElementExists(int id);

    }
}
