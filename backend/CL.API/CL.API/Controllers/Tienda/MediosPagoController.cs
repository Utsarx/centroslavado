using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.API.Controllers.Tienda
{/// <summary>
 /// Administarción de métodos de pago 
 /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MediosPagoController : ControllerBase
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<MediosPagoController> log;
        
        public MediosPagoController(
            ILogger<MediosPagoController> logger,
            ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }

        // POST api/<MediosPagoController>
        [HttpPost(Name = "PostMedioPago")]
        public ActionResult PostMedioPago([FromBody] MedioPago medioPago)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (db.MedioPagos.Any(x => x.Id == medioPago.Id))
            {
                return BadRequest();
            }

            db.MedioPagos.Add(medioPago); 
            db.SaveChanges();
            return Ok(medioPago.Id);
        }


        // DELETE api/<MediosPagoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            var mp = db.MedioPagos.Find(id);
            if (mp == null)
            {
                return NotFound(id);
            }

            db.MedioPagos.Remove(mp);
            db.SaveChanges();

            return NoContent();
        }
    }
}
