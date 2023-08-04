using System;
using Microsoft.AspNetCore.Mvc;
using PruebaPersonalSoft.Models;
using PruebaPersonalSoft.Services;

namespace PruebaPersonalSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
	{
        private readonly UserService service;

        public UserController(UserService _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("getUserAll")]
        public IActionResult GetUserPoliza()
        {
            var result = service.GetUsers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await service.AddUser(user);

            return Ok(user);
        }

    }
}

