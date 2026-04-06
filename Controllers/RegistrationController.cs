using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public IActionResult GetSampleData()
        {
            
            return Ok(new { Status = true, Guid = Guid.NewGuid() });
        }

    }
}
