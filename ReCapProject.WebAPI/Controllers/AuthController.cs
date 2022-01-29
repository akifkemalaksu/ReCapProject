using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Data.Entities.DTOs;

namespace ReCapProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthEngine _authEngine;

        public AuthController(IAuthEngine authEngine)
        {
            _authEngine = authEngine;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLogin)
        {
            var userToLogin = _authEngine.Login(userForLogin);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authEngine.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegister)
        {
            var userExists = _authEngine.UserExists(userForRegister.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _authEngine.Register(userForRegister);
            if (!registerResult.Success)
            {
                return BadRequest(registerResult.Message);
            }
            var result = _authEngine.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}