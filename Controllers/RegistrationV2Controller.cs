using Lesson.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Lesson.Controllers
{
    [Route("api/v2/Registration")]
    [ApiController]
    [ApiKeyClassAuthorize]
    public class RegistrationV2Controller : ControllerBase
    {
        [HttpGet("GetSampleData")]
        public IActionResult GetSampleData()
        {
            return Ok(new { Status = true, GUID = Guid.NewGuid(), Version = 2 });
        }
    }
}