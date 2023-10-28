using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class OrganizationController : ApiV1Conntroller
    {
        private readonly IOrganizationService _organizationService;
        private readonly IEmployeeService _employeeService;
        public OrganizationController(IOrganizationService organizationService, IEmployeeService employeeService)
        {
            _organizationService = organizationService;
            _employeeService = employeeService;
        }

        [HttpPost("add")]
        public IActionResult Add(OrganizationAddDto organizationAdd)
        {
            var organization = _organizationService.AddItem(organizationAdd);

            var employeReg = new EmployeeRegistrationDto()
            {
                Email = organizationAdd.Email,
                Firstname = organizationAdd.Firstname,
                Patronymic = organizationAdd.Patronymic,
                Surname = organizationAdd.Surname,
                DepartmentId = organization.Departments.First().Id
            };
            var result = _employeeService.AddItemChef(employeReg);


            return new JsonResult(result);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("edit")]
        public IActionResult Edit(OrganizationEditDto organizationEdit)
        {
            if (OrganizationIsUser(Convert.ToInt32(HttpContext.User.Identity!.Name), organizationEdit.Id))
            {
                return BadRequest(new JsonResult(new { message = "такой организации не существует" }));
            }
            _organizationService.EditItem(organizationEdit);
            return new JsonResult(new { message = "успешно обновлено" });
        }
        [Authorize(Roles = "superadmin")]
        [HttpPost("delete")]
        public IActionResult Delete(GetOrganizationDto getOrganizationDto)
        {
           
            var organizationUser = _employeeService.GetOrganizationById(Convert.ToInt32(HttpContext.User.Identity!.Name));
            var orgaization = _organizationService.GetItem(getOrganizationDto.Id);
            _organizationService.DeleteItem(getOrganizationDto);
            return new JsonResult(new { message = "успешно удалено" });
        }
        [Authorize]
        [HttpPost("getshort")]
        public IActionResult GetShort(GetOrganizationDto getOrganizationDto)
        {
            if (OrganizationIsUser(Convert.ToInt32(HttpContext.User.Identity!.Name), getOrganizationDto.Id))
            {
                return BadRequest(new JsonResult(new { message = "такой организации не существует" }));
            }
            var result = _organizationService.GetShortItem(getOrganizationDto);
            return new JsonResult(result);
        }
        [Authorize]
        [HttpPost("getlong")]
        public IActionResult GetLong(GetOrganizationDto getOrganizationDto)
        {
            if (OrganizationIsUser(Convert.ToInt32(HttpContext.User.Identity!.Name), getOrganizationDto.Id))
            {
                return BadRequest(new JsonResult(new { message = "такой организации не существует" }));
            }
            var result = _organizationService.GetLongItem(getOrganizationDto);
            return new JsonResult(result);
        }
        [Authorize(Roles = "superadmin")]
        [HttpGet("getalllong")]
        public IActionResult GetAllLong()
        {
            var result = _organizationService.GetAllLongItem();
            return new JsonResult(result);
        }

        [Authorize(Roles = "superadmin")]
        [HttpGet("getallshort")]
        public IActionResult GetAllShort()
        {
            var result = _organizationService.GetAllShortItem();
            return new JsonResult(result);
        }

        private bool OrganizationIsUser(int employeId, int organizationId)
        {
            var orgaizationUser = _employeeService.GetOrganizationById(employeId);
            if (orgaizationUser.Id != organizationId)
                return false;

            return true;
        }

    }
}
