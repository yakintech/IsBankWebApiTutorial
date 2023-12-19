using IsBankWebApiTutorial.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace IsBankWebApiTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public IActionResult Register(RegisterRequestDto model)
        {
            return Ok();
        }
    }
}
