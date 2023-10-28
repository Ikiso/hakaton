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
        //[Authorize(Roles = "superadmin")]
        //[HttpPost("add")]
        //public IActionResult Add(OrganizationAddDto organizationAdd)
        //{
        //    _organizationService.AddItem(organizationAdd);
        //    return new JsonResult(new { message = "успешно добавлено" });
        //}
        [Authorize(Roles = "admin")]
        [HttpPost("edit")]
        public IActionResult Edit(OrganizationEditDto organizationEdit)
        {

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

        [HttpPost("getshort")]
        public IActionResult GetShort(GetOrganizationDto getOrganizationDto)
        {
            var result = _organizationService.GetShortItem(getOrganizationDto);
            return new JsonResult(result);
        }

        [HttpPost("getlong")]
        public IActionResult GetLong(GetOrganizationDto getOrganizationDto)
        {
            var result = _organizationService.GetLongItem(getOrganizationDto);
            return new JsonResult(result);
        }

        [HttpGet("getalllong")]
        public IActionResult GetAllLong()
        {
            var result = _organizationService.GetAllLongItem();
            return new JsonResult(result);
        }

        [HttpGet("getallshort")]
        public IActionResult GetAllShort()
        {
            var result = _organizationService.GetAllShortItem();
            return new JsonResult(result);
        }
    }
}
