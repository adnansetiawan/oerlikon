using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oerlikon.Core.Models.Users;
using Oerlikon.WebApi.Dto;

namespace Oerlikon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Core.Interfaces.IUserRegisterService _userRegisterService;
        private readonly Core.Interfaces.IAuthService _authService;
        public AuthController(Core.Interfaces.IUserRegisterService userRegisterService, Core.Interfaces.IAuthService authService)
        {
            _userRegisterService = userRegisterService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationApiRequest request)
        {
            try
            {
                var response = await _userRegisterService.Register(new Core.Models.Users.UserRegisterRequest
                {
                    Email = request.Email,
                    Name = request.Name,
                    Password = request.Password
                });
                return Ok(response);
            }
            catch (Core.Exceptions.AuthException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginApiRequest request)
        {
            var response = await _authService.Login(new Core.Models.Users.UserLoginRequest
            {
                Email = request.Email,
                Password = request.Password
            });
            return Ok(response);
        }
    }
}
