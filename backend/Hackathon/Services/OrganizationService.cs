using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicationDbContext _context;
        public OrganizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adddepartment(Organization org,  Department department)
        {
            var organ = _context.Organizations.FirstOrDefault(a => a.Id == org.Id)!;
            organ.Departments.Add(department);

        }

        public Organization AddItem(OrganizationAddDto newOrganization)
        {
            var organization = new Organization()
            {
                Name = newOrganization.Name,
                Inn = newOrganization.INN,
                Address = newOrganization.Address,
                Description = newOrganization.Description,
                Mission = newOrganization.Mission,
                Goal = newOrganization.Target,
                Tariff = _context.Tariffs.Find(newOrganization.IdTariff)!,
                Color = _context.Colors.Find(1)!
            };


            _context.Organizations.Add(organization);
            _context.SaveChanges();
            return organization;
        }

        public void DeleteItem(GetOrganizationDto getOrganization)
        {
            var organization = _context.Organizations.Find(getOrganization.Id)!;
            _context.Organizations.Remove(organization);
            _context.SaveChanges();
        }

        public Organization EditItem(OrganizationEditDto newOrganization)
        {
            var organization = _context.Organizations.Find(newOrganization.Id)!;
            organization.Mission = newOrganization.Mission;
            organization.Tariff = _context.Tariffs.Find(newOrganization.IdTariff)!;
            organization.Inn = newOrganization.INN;
            organization.Address = newOrganization.Address;
            organization.Description = newOrganization.Description;
            organization.Mission = newOrganization.Mission;
            organization.Goal = newOrganization.Target;
            _context.Organizations.Update(organization);
            _context.SaveChanges();
            return organization;
        }

        public bool ElementExists(GetOrganizationDto getOrganization)
        {
            return _context.Organizations.Find(getOrganization.Id) != null;
        }

        public List<LongOrganizationDto> GetAllLongItem()
        {
            var result = new List<LongOrganizationDto>();
            foreach (var organization in _context.Organizations.Include(a => a.Tariff).ToList())
            {
                result.Add(new LongOrganizationDto()
                {
                    Address = organization.Address,
                    Description = organization.Description,
                    INN = organization.Inn,
                    Name = organization.Name,
                    Mission = organization.Mission,
                    Target = organization.Goal,
                    Tariff = organization.Tariff.Name
                });
            }

            return result;
        }

        public List<ShortOrganizationDto> GetAllShortItem()
        {
            var result = new List<ShortOrganizationDto>();
            foreach (var organization in _context.Organizations.Include(a => a.Tariff).ToList())
            {
                result.Add(new ShortOrganizationDto()
                {
                    Description = organization.Description,
                    Name = organization.Name,
                });
            }

            return result;
        }

        public Organization GetItem(int id)
        {
            return _context.Organizations.Include(a=>a.Departments).FirstOrDefault(a => a.Id == id)!;
        }

        public LongOrganizationDto GetLongItem(GetOrganizationDto getOrganization)
        {
            var organization = _context.Organizations.Include(a => a.Tariff).FirstOrDefault(a => a.Id == getOrganization.Id)!;
            var result = new LongOrganizationDto()
            {
                Address = organization.Address,
                Description = organization.Description,
                INN = organization.Inn,
                Name = organization.Name,
                Mission = organization.Mission,
                Target = organization.Goal,
                Tariff = organization.Tariff.Name
            };

            return result;
        }

        public ShortOrganizationDto GetShortItem(GetOrganizationDto getOrganization)
        {
            var organization = _context.Organizations.Include(a => a.Tariff).FirstOrDefault(a => a.Id == getOrganization.Id)!;
            var result = new ShortOrganizationDto()
            {
                Description = organization.Description,
                Name = organization.Name,
            };

            return result;
        }
    }
}
