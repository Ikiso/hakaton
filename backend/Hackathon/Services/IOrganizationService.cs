using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IOrganizationService
    {
        public Organization AddItem(OrganizationAddDto newOrganization);
        public Organization EditItem(OrganizationEditDto newOrganization);
        public ShortOrganizationDto GetShortItem(GetOrganizationDto getOrganization);
        public LongOrganizationDto GetLongItem(GetOrganizationDto getOrganization);
        public List<ShortOrganizationDto> GetAllShortItem(GetOrganizationDto getOrganization);
        public List<LongOrganizationDto> GetAllLongItem(GetOrganizationDto getOrganization);
        public void DeleteItem(GetOrganizationDto getOrganization);
        public bool ElementExists(GetOrganizationDto getOrganization);

    }
}
