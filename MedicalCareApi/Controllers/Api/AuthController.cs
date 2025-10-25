
using MedicalCareApi.DTOs.User;
using MedicalCareApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCareApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _userService.LoginAsync(request);
            if (response == null)
                return Unauthorized("Invalid credentials");

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequestDto request)
        {
            var user = await _userService.RegisterUserAsync(request);
            return Ok(user);
        }
    }
}
