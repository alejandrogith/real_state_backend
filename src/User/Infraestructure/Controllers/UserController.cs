
using Microsoft.AspNetCore.Mvc;

namespace Real_state_Backend.src.User.Infraestructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {

            var amd = 2 * 10;


            return Ok(new string[] { "ASD", "ASDASDD" });
        }
    }
}