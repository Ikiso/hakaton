using Hackathon.Dtos;
using Hackathon.Models;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class UsersController : ApiV1Conntroller
    {
        readonly IAuthService _authService;
        readonly IUserService _userService;
        readonly IEmployeeService _employeeService;
        public UsersController(IAuthService authService, IUserService userService, IEmployeeService employeeService)
        {
            _authService = authService;
            _userService = userService;
            _employeeService = employeeService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto input)
        {
            if (!_authService.IsRegistred(input))
            {
                return StatusCode(401, new { message = "Аутентификация не пройдена" });
            }

            var user = _userService.GetItemWithAccount(input.Email);

            // Если пользователей 1, то сразу логиниттся, иначе возращается массив Работников, зарегестрированных на один акк
            if (user.Employees.Count == 1)
            {
                var accessToken = _authService.Login(user.Employees.First().Id);
                return new JsonResult(new { accessToken });
            }
            else
            {
                var result = new List<UserOrganizationsDto>();

                foreach (var e in user.Employees)
                {
                    result.Add(new UserOrganizationsDto
                    {
                        EmployeeId = e.Id,
                        OrganizationName = _employeeService.GetOrganizationNameById(e.Id)
                    });
                }
                return new JsonResult(result);
            }
        }

        [HttpPost("loginmany")]
        public IActionResult LoginManyOrganization(LoginManyOrganization input)
        {
            if (!_authService.IsRegistred(new LoginDto() { Email = input.Email, Password = input.Password}))
            {
                return StatusCode(401, new { message = "Аутентификация не пройдена" });
            }

            var accessToken = _authService.Login(input.EmployeeId);
            return new JsonResult(new { accessToken });
        }

    }
}
