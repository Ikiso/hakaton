using Hackathon.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace Hackathon.Controllers
{
    public class TariffController : ApiV1Conntroller
    {
        private readonly ITariffService _tariffService;
        public TariffController(ITariffService tariffService)
        {
            _tariffService = tariffService;

        }

        [Authorize(Roles = "superadmin")]
        [HttpPost("add")]
        public IActionResult Add(TariffAdd tariffAdd)
        {
            var tariff = _tariffService.AddItem(tariffAdd);
            return new JsonResult(new { message = "успешно добавлено" });
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost("get")]
        public IActionResult Get(TariffGet tariffGet)
        {
            var tariff = _tariffService.GetItemDto(tariffGet);
            return new JsonResult(tariff);
        }

        [Authorize(Roles = "superadmin")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var tariff = _tariffService.GetAll();
            return new JsonResult(tariff);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost("edit")]
        public IActionResult Edit(TariffEdit tariffEdit)
        {
            var tariff = _tariffService.EditItem(tariffEdit);
            return new JsonResult(tariff);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost("delete")]
        public IActionResult Delete(TariffGet tariffGet)
        {
            _tariffService.RemoveItem(tariffGet);
            return new JsonResult(new { message = "успешно удалено" });
        }
    }
}
