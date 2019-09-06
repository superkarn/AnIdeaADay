using AIAD.Library.Models;
using AIAD.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIAD.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : BaseController
    {
        private readonly IJwtService jwtService;

        public JwtController(IJwtService authenticationService)
        {
            this.jwtService = authenticationService;
        }

        // POST api/jwt/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]JwtUser userObj)
        {
            var user = this.jwtService.Authenticate(userObj.Token);

            if (user == null)
            {
                return BadRequest(new { message = "The token is invalid." });
            }

            return Ok(user);
        }

        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return "success";
        }
    }
}
