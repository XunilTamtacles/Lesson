using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpGet("v1/GetSampleData")]
        public IActionResult GetSampleData()
        {
            
            return Ok(new { Status = true, Guid = Guid.NewGuid() });
        }

        [HttpGet("v2/GetSampleData")]
        public IActionResult GetAnotherSampleData()
        {
            return Ok(new { Status = true, Guid = Guid.NewGuid(), Version = 2 });
        }

  
    }
}
