using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class DepartmentController : ApiV1Conntroller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        public DepartmentController(IOrganizationService organizationService, IUserService userService, IDepartmentService departmentService)
        {
            _organizationService = organizationService;
            _userService = userService;
            _departmentService = departmentService;

        }
        [Authorize(Roles =("director"))]
        [HttpPost("add")]
        public IActionResult Add(DepartmentAddDto departmentAdd)
        {
           
            return new JsonResult(new { message = "успешно добавлено" });
        }
    }
}
