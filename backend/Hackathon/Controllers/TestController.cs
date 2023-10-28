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

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("add")]
        public IActionResult Add(AddTestDto input)
        {
            int id = _testService.AddItem(input);
            return new JsonResult(new { id });
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("delete")]
        public IActionResult Delete(DeleteTestDto input)
        {
           _testService.DeleteItem(input.Id);
            return Ok();
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("getshort")]
        public IActionResult GetShort(GetTestByIdDto input)
        {
            var result = _testService.GetItemShort(input.Id);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("getallshort")]
        public IActionResult GetAllShort(GetAllTestsDto input)
        {
            var result = _testService.GetAllShort(input);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("getlong")]
        public IActionResult GetLong(GetTestByIdDto input)
        {
            var result = _testService.GetItemLong(input.Id);
            return new JsonResult(result);
        }

        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("getalllong")]
        public IActionResult GetAllLong(GetAllTestsDto input)
        {
            var result = _testService.GetAllLong(input);
            return new JsonResult(result);
        }



        [Authorize(Roles = "admin,superadmin,hr")]
        [HttpPost("edit")]
        public IActionResult Edit(EditTestDto input)
        {
            _testService.EditItem(input);
            return Ok();
        }

        public record DeleteTestDto(int Id);
        public record GetTestByIdDto(int Id);

    }
}
