
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson.Controllers
{
    [Route("api/v1/Registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpGet("GetSampleData")]
        public IActionResult GetSampleData()
        {
            return Ok(new { Status = true, GUID = Guid.NewGuid() });
        }
    }
}