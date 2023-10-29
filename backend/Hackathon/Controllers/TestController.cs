using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class TestController : ApiV1Conntroller
    {
        private readonly ITestService _testService;

        public TestController(IAuthService authService, ITestService testService)
        {
            _testService = testService;
        }

        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpGet("passed")]
        public IActionResult Passed()
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            var result = _testService.GetPassedTests(employeeId);

            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpGet("passedshort")]
        public IActionResult PassedShort()
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            var result = _testService.GetPassedByLastAttTests(employeeId);

            return new JsonResult(result);
        }


        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpPost("solution")]
        public IActionResult Solution(AttemptTestDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedEmployee(employeeId, input.TestId))
            {
                return NotFound();
            }

            var result = _testService.SolutionTest(input, employeeId);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("add")]
        public IActionResult Add(AddTestDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedByCourseId(employeeId, input.CourseId))
            {
                return NotFound();
            }

            int id = _testService.AddItem(input);
            return new JsonResult(new { id });
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("delete")]
        public IActionResult Delete(DeleteTestDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedEmployee(employeeId, input.Id))
            {
                return NotFound();
            }

            _testService.DeleteItem(input.Id);
            return Ok();
        }

        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpPost("getshort")]
        public IActionResult GetShort(GetTestByIdDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedEmployee(employeeId, input.Id))
            {
                return NotFound();
            }


            var result = _testService.GetItemShort(input.Id);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpPost("getallshort")]
        public IActionResult GetAllShort(GetAllTestsDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedByCourseId(employeeId, input.CourseId))
            {
                return NotFound();
            }

            var result = _testService.GetAllShort(input);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpPost("getallinfo")]
        public IActionResult GetAllShortinfo(GetAllTestsDto input)
        {

            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedByCourseId(employeeId, input.CourseId))
            {
                return NotFound();
            }

            var result = _testService.GetAllWithAttInfo(input, employeeId);
            return new JsonResult(result);
        }


        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpPost("getlong")]
        public IActionResult GetLong(GetTestByIdDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedEmployee(employeeId, input.Id))
            {
                return NotFound();
            }

            var result = _testService.GetItemLong(input.Id);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr,user")]
        [HttpPost("getalllong")]
        public IActionResult GetAllLong(GetAllTestsDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedByCourseId(employeeId, input.CourseId))
            {
                return NotFound();
            }

            var result = _testService.GetAllLong(input);
            return new JsonResult(result);
        }



        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("edit")]
        public IActionResult Edit(EditTestDto input)
        {
            int employeeId = Convert.ToInt32(HttpContext.User.Identity!.Name);
            if (!_testService.AccessAllowedEmployee(employeeId, input.Id))
            {
                return NotFound();
            }

            _testService.EditItem(input);
            return Ok();
        }

        public record DeleteTestDto(int Id);
        public record GetTestByIdDto(int Id);

    }
}
