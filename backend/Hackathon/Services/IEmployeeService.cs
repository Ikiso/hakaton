using Hackathon.Dtos;

namespace Hackathon.Services
{
    public interface IEmployeeService
    {
        string GetRoleById(int id);
        string GetOrganizationNameById(int id);
        RegistrationResultDto AddItem(EmployeeRegistrationDto input);
    }
}
