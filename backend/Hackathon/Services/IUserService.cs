using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IUserService
    {
        bool IsExists(string email);
        User GetItemWithAccount(string email);
    }
}
