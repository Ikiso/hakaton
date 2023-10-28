using Hackathon.Dtos;
using Hackathon.Models;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class DepartmentController : ApiV1Conntroller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IOrganizationService _organizationService;

        public record class GetAllDepartment(int OrganizationId);
        public DepartmentController(IOrganizationService organizationService, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _organizationService = organizationService;
            _employeeService = employeeService;
            _departmentService = departmentService;

        }

        [Authorize(Roles = "admin")]
        [HttpPost("add")]
        public IActionResult Add(DepartmentAddDto departmentAdd)
        {

            var organization = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
            var department = _departmentService.AddItem(departmentAdd);
            _organizationService.Adddepartment(organization, department);
            return new JsonResult(new { message = "успешно добавлено" });
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addchild")]
        public IActionResult AddChild(DepartmentAddDto departmentAdd)
        {
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), departmentAdd.DepartmentId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого отдела" }));
            }

            var organization = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
            var department = _departmentService.AddChildItem(departmentAdd);
            _organizationService.Adddepartment(organization, department);
            return new JsonResult(new { message = "успешно добавлено" });
        }

        [Authorize(Roles = "admin")]
        [HttpPost("delete")]
        public IActionResult Delete(GetDepartmentDto getDepartment)
        {
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), getDepartment.Id))
            {
                return BadRequest(new JsonResult(new { message = "нет такого отдела" }));
            }

            _departmentService.DeleteItem(getDepartment);
            return new JsonResult(new { message = "успешно удалено" });
        }

        [Authorize(Roles = "admin")]
        [HttpPost("edit")]
        public IActionResult Edit(DepartmentEditDto editDepartment)
        {
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), editDepartment.Id))
            {
                return BadRequest(new JsonResult(new { message = "нет такого отдела" }));
            }

            var result = _departmentService.EditItem(editDepartment);
            return new JsonResult(new { message = "успешно отредактировано" });
        }


        [Authorize(Roles = "admin, user")]
        [HttpPost("get")]
        public IActionResult Get(GetDepartmentDto getDepartment)
        {
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), getDepartment.Id))
            {
                return BadRequest(new JsonResult(new { message = "нет такого отдела" }));
            }

            var result = _departmentService.GetItem(getDepartment);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("getall")]
        public IActionResult GetAll(GetAllDepartment getAllDepartment)
        {
            var organizationUser = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
            var organization = _organizationService.GetItem(getAllDepartment.OrganizationId);
            if (organizationUser.Id != organization.Id)
            {
                return BadRequest(new JsonResult(new { message = "нет такой организации" }));
            }

            var result = _departmentService.GetAllItem(getAllDepartment.OrganizationId);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("getall")]
        public IActionResult GetAllNotParam()
        {
            var organizationUser = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
          

            var result = _departmentService.GetAllItem(organizationUser.Id);
            return new JsonResult(result);
        }

        private bool CheckOrganization(int idEmploye, int departmentId)
        {
            var organizationUser = _employeeService.GetOrganizationById(idEmploye);
            var organization = _departmentService.ItemGet(departmentId).Organization;
            if (organization.Id != organizationUser.Id)
                return false;

            return true;
        }

    }
}
