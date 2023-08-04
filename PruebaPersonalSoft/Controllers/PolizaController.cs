using System;
using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using PruebaPersonalSoft.Config.Helpers;
using PruebaPersonalSoft.Models;
using PruebaPersonalSoft.Repositories.Polizas;

namespace PruebaPersonalSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {
        private IPolizaCollection db = new PolizaCollection();
        
        [HttpGet]
        [Route("getListAll")]
        public async Task<IActionResult> GetAllPoliza()
        {
            return Ok(await db.GetAllPoliza());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoliza( string id)
        {
            return Ok(await db.GetPolizaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPoliza([FromBody] Poliza poliza)
        {
           if(poliza == null)
            {
                return BadRequest();
            }

            await db.IserttPoliza(poliza);

            return Created("Created", true);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AddPoliza([FromBody] Poliza poliza, string id)
        {
            if (poliza == null)
            {
                return BadRequest();
            }

            poliza.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdatePoliza(poliza);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliza(string id)
        {
           
            await db.DeletePoliza(id);

            return NoContent();
        }

    }
}

