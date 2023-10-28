using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IEmployeeService
    {
        string GetRoleById(int id);
        string GetOrganizationNameById(int id);
        Organization GetOrganizationById(int id);
        void AddItem(EmployeeRegistrationDto input);
    }
}
