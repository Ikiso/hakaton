using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    abstract public class ApiV1Conntroller : ControllerBase
    {
    }
}
