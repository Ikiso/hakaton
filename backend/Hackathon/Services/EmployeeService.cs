using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;
using PasswordGenerator;
using System.Web;

namespace Hackathon.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;


        public EmployeeService(ApplicationDbContext dbContext, IUserService userService, IAuthService authService) 
        { 
            _context = dbContext;
            _userService = userService;
            _authService = authService;
        }

        public RegistrationResultDto AddItem(EmployeeRegistrationDto input)
        {
            Department department = _context.Departments.Find(input.DepartmentId)!;
            Employee employee = null!;
            RegistrationResultDto result = null!;

            if (_userService.IsExists(input.Email))
            {
                employee = new Employee()
                {
                    Department = department,
                    User = _userService.GetItem(input.Email),
                    // Просто user
                    Role = _context.Roles.Find(4)!,
                    // Работает
                    Status = _context.Statuses.Find(1)!
                };

                result = new RegistrationResultDto()
                {
                    IsNewUser = false
                };
            }
            else
            {
                var pwd = new Password(passwordLength: 9, includeSpecial: false, includeLowercase: true, includeUppercase: true, includeNumeric: true);
                string password = pwd.Next();
                string passwordHash = _authService.EncodePassword(password);
                

                Account account = new Account()
                {
                    Email = input.Email,
                    PasswordHash = passwordHash
                };


                User user = new User()
                {
                    Account = account,
                    Firstname = input.Firstname,
                    Surname = input.Surname,
                    Patronymic = input.Patronymic
                };

                employee = new Employee()
                {
                    User = user,
                    Department = department,
                    // Просто user
                    Role = _context.Roles.Find(4)!,
                    // Работает
                    Status = _context.Statuses.Find(1)!
                };

                _context.Accounts.Add(account);
                _context.Users.Add(user);

                result = new RegistrationResultDto()
                {
                    Email = input.Email,
                    Password = password,
                    IsNewUser = true
                };

            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return result;
        }

        public Organization GetOrganizationById(int id)
        {
            return _context.Employees.Include(e => e.Department).
                ThenInclude(d => d.Organization).
                FirstOrDefault(e => e.Id == id)!.Department.Organization;
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
