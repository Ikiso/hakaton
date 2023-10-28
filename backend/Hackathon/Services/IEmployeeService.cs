using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IEmployeeService
    {
        string GetRoleById(int id);
        string GetOrganizationNameById(int id);
        RegistrationResultDto AddItem(EmployeeRegistrationDto input);
        Organization GetOrganizationById(int id);
        void AddItem(EmployeeRegistrationDto input);
    }
}
