using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class OrganizationController : ApiV1Conntroller
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost("add")]
        public IActionResult Add(OrganizationAddDto organizationAdd)
        {
            _organizationService.AddItem(organizationAdd);
            return new JsonResult(new { message = "успешно добавлено" });
        }

        [HttpPost("edit")]
        public IActionResult Edit(OrganizationEditDto organizationEdit)
        {
            _organizationService.EditItem(organizationEdit);
            return new JsonResult(new { message = "успешно обновлено" });
        }

        [HttpPost("delete")]
        public IActionResult Delete(GetOrganizationDto getOrganizationDto)
        {
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

        [HttpPost("getalllong")]
        public IActionResult GetAllLong(GetOrganizationDto getOrganizationDto)
        {
            var result = _organizationService.GetAllLongItem(getOrganizationDto);
            return new JsonResult(result);
        }

        [HttpPost("getallshort")]
        public IActionResult GetAllShort(GetOrganizationDto getOrganizationDto)
        {
            var result = _organizationService.GetAllShortItem(getOrganizationDto);
            return new JsonResult(result);
        }
    }
}
