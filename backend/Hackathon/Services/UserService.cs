using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;   
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
    }
}
