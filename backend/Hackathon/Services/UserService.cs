using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        //private readonly IEmployeeService _employeeService;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            //_employeeService = employeeService;
        } 

        public User? GetItem(string email)
        {
            return _context.Users.Include(u => u.Account).FirstOrDefault(u => u.Account.Email == email);
        }

        public User? GetItemById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetItemWithAccount(string email)
        {
            return _context.Users.Include(u => u.Account).Include(u=>u.Employees).FirstOrDefault(u => u.Account.Email == email)!;
        }

        public bool IsExists(string email)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email) != null;
        }

        public bool UserExistsInOrganization(int idOrganization, string email)
        {
            var users = _context.Users.Include(u => u.Account).
                Include(u => u.Employees).
                ThenInclude(e=>e.Department).ThenInclude(d=>d.Organization).
                FirstOrDefault(u => u.Account.Email == email)!;

            var employees = users.Employees;

            foreach (var e in employees)
            {
                if (e.Department.OrganizationId == idOrganization)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
