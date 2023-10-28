using Hackathon.Dtos;

namespace Hackathon.Services
{
    public interface IAuthService
    {
        string Login(int employeeIdlClaim);
        bool IsRegistred(LoginDto input);
        string EncodePassword(string password);
    }
}
