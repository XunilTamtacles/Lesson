using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.RateLimiting;
using SampleAPI.Models;

namespace Lesson.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [ApiKeyClassAuthorize]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService = new JwtService();

        [EnableRateLimiting("PerAPIKey")]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel.Username == "admin" && loginModel.Password == "admin")
            {
                var token = _jwtService.GenerateToken(loginModel.Username, "Admin");
                return Ok(new { token });
            }

            return BadRequest();
        }

    }
}
