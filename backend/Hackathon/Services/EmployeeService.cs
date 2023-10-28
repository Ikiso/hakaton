using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public EmployeeService(ApplicationDbContext dbContext) 
        { 
            _context = dbContext;
            _userService = new UserService(dbContext);
        }

        public void AddItem(EmployeeRegistrationDto input)
        {
            Department department = _context.Departments.Find(input.DepartmentId)!;
            User user = null!;
            string password = "";
            bool emailExists = false;

            if (_userService.IsExists(input.Email))
            {
                user = _userService.GetItemWithAccount(input.Email);
                emailExists = true;
            }

            Employee employee = new Employee();

        }

        public string GetOrganizationNameById(int id)
        {
            return _context.Employees.Include(e => e.Department).
                ThenInclude(d => d.Organization).
                FirstOrDefault(e => e.Id == id)!.Department.Organization.Name;
        }

        public string GetRoleById(int id)
        {
            return _context.Employees.Include(e => e.Role).FirstOrDefault(e=>e.Id == id)!.Role.Name;
        }
    }
}
