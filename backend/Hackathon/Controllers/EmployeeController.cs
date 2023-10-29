using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Hackathon.Controllers.CoursesController;

namespace Hackathon.Controllers
{
    public class EmployeeController : ApiV1Conntroller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [Authorize(Roles = "admin, hr")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var organization = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
            
            var result = _employeeService.GetAll(organization.Id);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("edit")]
        public IActionResult Edit(EmployeeEditDto input)
        {

            var organization = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
            var organizationEditEmployee = _departmentService.ItemGet(input.DepartmentId).OrganizationId;
            var organizationEnp = _employeeService.GetOrganizationById(_employeeService.GetById(input.id)!.Id);

            if (organization.Id != organizationEnp.Id)
                return BadRequest(new JsonResult(new { message = "нет такого сотрудника" }));

            if (organization.Id != organizationEditEmployee)
                return BadRequest(new JsonResult(new { message = "нет такого сотрудника"}));
            
            if(input.RoleId == 1)
                return BadRequest(new JsonResult(new { message = "не верный формат" }));

            _employeeService.EditItem(input);
            return new JsonResult(new { message= "успешно обновлено"});
        }

    }
}
