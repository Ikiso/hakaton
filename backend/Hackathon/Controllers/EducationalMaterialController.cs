using Hackathon.Dtos;
using Hackathon.Models;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class EducationalMaterialController : ApiV1Conntroller
    {
        private readonly IEducationalMaterialService _educationalMaterialService;
        private readonly ICourseService _courseService;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public record class GetAllEducational(int CourseId);
        public EducationalMaterialController(IEducationalMaterialService educationalMaterialService, ICourseService courseService, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _educationalMaterialService = educationalMaterialService;
            _courseService = courseService;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("add")]
        public IActionResult Add(EducationalMaterialCreate materialCreate)
        {

            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), materialCreate.CourseId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            _educationalMaterialService.AddItem(materialCreate);
            return new JsonResult(new { message = "успешно добавлено" });
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("delete")]
        public IActionResult Delete(EducationalMaterialGet materialGet)
        {
            var material = _educationalMaterialService.GetItem(materialGet);
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), material.CourseId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            _educationalMaterialService.DelteItem(materialGet);
            return new JsonResult(new { message = "успешно удалено" });
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("edit")]
        public IActionResult Edit(EducationalMaterialEdit materialEdit)
        {
            var material = _educationalMaterialService.GetItem(new EducationalMaterialGet(materialEdit.Id));
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), material.CourseId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), materialEdit.CourseId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            _educationalMaterialService.EditItem(materialEdit);
            return new JsonResult(new { message = "успешно обновлено" });
        }

        [Authorize(Roles = "admin, hr, user")]
        [HttpPost("get")]
        public IActionResult Get(EducationalMaterialGet educationalMaterial)
        {
            var material = _educationalMaterialService.GetItem(educationalMaterial);
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), material.CourseId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            var result = _educationalMaterialService.GetItemDto(educationalMaterial);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin, hr, user")]
        [HttpPost("getall")]
        public IActionResult GetAll(GetAllEducational getAllEducational)
        {
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), getAllEducational.CourseId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            var result = _educationalMaterialService.GetAllItemDto(getAllEducational.CourseId);
            return new JsonResult(result);
        }

        private bool CheckOrganization(int idEmploye, int courseId)
        {
            var course = _courseService.GetItem(new GetCourseDto() { Id = courseId });
            if (course == null)
                return false;
            var organizationUser = _employeeService.GetOrganizationById(idEmploye);
            var organization = _departmentService.ItemGet(course.DepartmentId).Organization;
            if (organization.Id != organizationUser.Id)
                return false;

            return true;
        }
    }
}
