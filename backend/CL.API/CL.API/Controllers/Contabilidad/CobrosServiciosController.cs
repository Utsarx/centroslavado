using CL.Modelo.Contabilidad;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.API.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrosServiciosController : ControllerBase
    {
        protected readonly ContextoAplicacion db;
        protected readonly ILogger<CobrosServiciosController> log; 
        
        public CobrosServiciosController(ILogger<CobrosServiciosController> logger, ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger; 
        }
        // GET: api/<CobrosServiciosController>
        [HttpGet]
        public ActionResult<IEnumerable<CobroServicio>> Get()
        {

            return db.CobroServicios.ToList().OrderBy(x => x.Id).ToList();
        }
        // GET api/<CobrosServiciosController>/5
        [HttpGet("{id}")]
        public ActionResult<CobroServicio> Get(int id)
        {
            log.LogError($"Id {id}");
            var cobro = db.CobroServicios.Find(id); 
            if(cobro == null)
            {
                return NotFound(id); 
            }
            return Ok(cobro); 
        }

        // POST api/<CobrosServiciosController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] CobroServicio cobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            cobro.Id = new int();
            db.CobroServicios.Add(cobro);
            db.SaveChanges();
            return Ok(cobro.Id); 
        }

        // PUT api/<CobrosServiciosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CobroServicio cobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            var cob = db.CobroServicios.Find(id); 
            if (cob == null)
            {
                return NotFound(id); 
            }

            //LINQ
            var cobrotemp = db.CobroServicios.Where(
                xcobrotemp => xcobrotemp.Fecha == cobro.Fecha
                && xcobrotemp.Id != id).SingleOrDefault();

            if (cobrotemp != null)
            {
                return Conflict(cobro.Fecha); 
            }

            cobrotemp = db.CobroServicios.Where(
                xcobrotemp => xcobrotemp.Monto == cobro.Monto
                && xcobrotemp.Id != id).SingleOrDefault(); 

            if(cobrotemp != null)
            {
                return Conflict(cobro.Monto); 
            }

            cob.Fecha = cobro.Fecha;
            cob.Monto = cobro.Monto;

            db.SaveChanges();
            return NoContent(); 
        }

        // DELETE api/<CobrosServiciosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            log.LogError($"Eliminar Id {id}");
            var cobro = db.CobroServicios.Find(id); 
            if(cobro == null)
            {
                return NotFound(id); 
            }

            db.CobroServicios.Remove(cobro);
            db.SaveChanges();
            return NoContent(); 
        }
    }
}
