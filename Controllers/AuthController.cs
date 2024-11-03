using diskusiPR.helpers;
using diskusiPR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diskusiPR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthHelpers authHelpers;

        public AuthController(AuthHelpers authHelpers)
        {
            this.authHelpers = authHelpers;
        }

        [HttpPost("generate-token")]

        public IActionResult GenerateToken([FromBody] User user)
        {
            var token = authHelpers.GenerateJWTToken(user);
            return Ok(new {token});
        }

    }
}
