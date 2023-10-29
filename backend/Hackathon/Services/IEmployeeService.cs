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
        bool EmployeeExistsInCurrentUser(int employeeId, string email);
        public RegistrationResultDto AddItemChef(EmployeeRegistrationDto input);
        public Employee EditItem(EmployeeEditDto input);
        public List<EmployeeGetDto> GetAll(int idOrganization);
        public Employee GetById(int id);
    }
}
