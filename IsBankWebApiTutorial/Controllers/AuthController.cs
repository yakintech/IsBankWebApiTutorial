using IsBankWebApiTutorial.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IsBankWebApiTutorial.Models.AuthOperations;

namespace IsBankWebApiTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //usermanager ve signinmanager kullanilacak
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto model)
        {
            //kayit islemi
            var userCheck = await _userManager.FindByEmailAsync(model.EMail);

            if (userCheck != null)
            {
                return BadRequest("Bu email adresi kullanilmaktadir.");
            }

            var user = new IdentityUser
            {
                Email = model.EMail,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var tokenHandler = new IsBankTokenHandler();
                var token = tokenHandler.CreateAccessToken(user.Email);

                return Ok(token);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            //login islemi
            var user = await _userManager.FindByEmailAsync(model.EMail);

            if (user == null)
            {
                return BadRequest("Kullanici adi veya sifre hatali!");
            }

            var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                var tokenHandler = new IsBankTokenHandler();
                var token = tokenHandler.CreateAccessToken(user.Email);

                return Ok(token);
            }
            else
            {
                return BadRequest("Kullanici adi veya sifre hatali!");
            }
        }
    }
}
