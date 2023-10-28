using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class CoursesController : ApiV1Conntroller
    {
        private readonly ICourseService _courseService;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public CoursesController(ICourseService courseService, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _courseService = courseService;
            _employeeService = employeeService;
            _departmentService = departmentService;

        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("add")]
        public IActionResult Add(CourseAddDto courseAdd)
        {

            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), courseAdd.DepartmentId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого отдела" }));
            }
            _courseService.AddItem(courseAdd);
            return new JsonResult(new { message = "успешно добавлено" });
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("edit")]
        public IActionResult Edit(CourseEditDto courseEdit)
        {

            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), courseEdit.DepartmentId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            _courseService.EditItem(courseEdit);
            return new JsonResult(new { message = "успешно обновлено" });
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("delete")]
        public IActionResult Delete(GetCourseDto getCourse)
        {
            var course = _courseService.GetItem(getCourse);
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), course.DepartmentId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            _courseService.DelteItem(getCourse);
            return new JsonResult(new { message = "успешно удалено" });
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("get")]
        public IActionResult Get(GetCourseDto getCourse)
        {
            var course = _courseService.GetItem(getCourse);
            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), course.DepartmentId))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }

            return new JsonResult(course);
        }

        [Authorize(Roles = "admin, hr")]
        [HttpPost("getall")]
        public IActionResult GetAll(GetDepartmentDto getDepartment)
        {

            if (!CheckOrganization(Convert.ToInt32(HttpContext.User.Identity!.Name), getDepartment.Id))
            {
                return BadRequest(new JsonResult(new { message = "нет такого курса" }));
            }
            var result = _courseService.GetItemDtoAll(getDepartment);
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
