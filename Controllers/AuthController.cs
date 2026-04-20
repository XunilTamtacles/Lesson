using Lesson.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Lesson.Models;
using Lesson.Utils;

namespace Lesson.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [ApiKeyAuthorize]
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