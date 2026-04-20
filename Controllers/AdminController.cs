using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserStats()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "SUPER_ADMIN")]
        public IActionResult GetUserStatsAll()
        {
            throw new NotImplementedException();
        }
    }
}