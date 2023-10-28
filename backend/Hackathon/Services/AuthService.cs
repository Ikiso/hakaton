using Hackathon.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Hackathon.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IEmployeeService employeeService, IUserService userService)
        {
            _configuration = configuration;
            _employeeService = employeeService;
            _userService = userService;
        }

        public static string EncodePassword(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        public bool IsRegistred(LoginDto input)
        {
            if (!_userService.IsExists(input.Email))
            {
                return false;
            }

            var cipher = EncodePassword(input.Password);

            var user = _userService.GetItemWithAccount(input.Email);
            if (user.Account.PasswordHash  == cipher) 
            {
                return true;
            }
            return false;
        }

        public string Login(int employeeIdClaim)
        {
            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, employeeIdClaim.ToString()), new Claim(ClaimTypes.Role, _employeeService.GetRoleById(employeeIdClaim)) };

            var authConf = new AuthOptionsConfig();
            _configuration.GetSection("AuthOptions").Bind(authConf);

            var jwt = new JwtSecurityToken(
                issuer: authConf.Issuer,
                audience: authConf.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConf.Key)), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
