using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IOrganizationService
    {
        public Organization AddItem(OrganizationAddDto newOrganization);
        public Organization EditItem(OrganizationEditDto newOrganization);
        public Organization GetItem(int id);
        public void Adddepartment(Organization org, Department department);
        public ShortOrganizationDto GetShortItem(GetOrganizationDto getOrganization);
        public LongOrganizationDto GetLongItem(GetOrganizationDto getOrganization);
        public List<ShortOrganizationDto> GetAllShortItem();
        public List<LongOrganizationDto> GetAllLongItem();
        public void DeleteItem(GetOrganizationDto getOrganization);
        public bool ElementExists(GetOrganizationDto getOrganization);


    }
}
