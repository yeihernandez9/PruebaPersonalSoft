using System;
using Microsoft.AspNetCore.Mvc;
using PruebaPersonalSoft.Models;
using PruebaPersonalSoft.Services;

namespace PruebaPersonalSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController: ControllerBase
	{
        private readonly AuthService service;

        public AuthController(AuthService _service)
        {
            service = _service;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Auth auth)
        {
            var response = service.Authenticate(auth).Result;

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}

