using CL.Modelo;
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
    public class AbonosPrepagoController : ControllerBase
    {
        protected readonly ContextoAplicacion db;
        protected readonly ILogger<AbonosPrepagoController> log; 
        public AbonosPrepagoController(ContextoAplicacion contexto, ILogger<AbonosPrepagoController> logger)
        {
            db = contexto;
            log = logger; 
        }
        // GET: api/<AbonosPrepagoController>
        [HttpGet]
        public ActionResult<IEnumerable<AbonoPrepago>> Get()
        {
            return db.AbonosPrepago.ToList().OrderBy(x => x.Id).ToList();
        }

        // GET api/<AbonosPrepagoController>/5
        [HttpGet("{id}")]
        public ActionResult<AbonoPrepago> Get(Guid id)
        {
            log.LogError($"Id {id}");
            var abono = db.AbonosPrepago.Find(id); 
            if(abono == null)
            {
                return NotFound(id); 
            }
            return Ok(abono); 
        }


        // POST api/<AbonosPrepagoController>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] AbonoPrepago abono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            abono.Id = Guid.NewGuid();
            db.AbonosPrepago.Add(abono);
            db.SaveChanges();
            return (abono.Id); 
        }

        // PUT api/<AbonosPrepagoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] AbonoPrepago abono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            var ab = db.AbonosPrepago.Find(id);
            if (ab == null)
            {
                return NotFound(id); 
            }

            //LINQ 

            var abonotemp = db.AbonosPrepago.Where(
                xabono => xabono.Fecha == abono.Fecha
                && xabono.Id != id).SingleOrDefault();
            if (abonotemp != null)
            {
                return Conflict(abono.Fecha); 
            }

            abonotemp = db.AbonosPrepago.Where(
                xabono => xabono.Monto == abono.Monto
                && xabono.Id != id).SingleOrDefault();
            if (abonotemp != null)
            {
                return Conflict(abono.Monto);
            }

            abonotemp = db.AbonosPrepago.Where(
                xabono => xabono.Moneda == abono.Moneda
                && xabono.Id != id).SingleOrDefault();
            if (abonotemp != null)
            {
                return Conflict(abono.Moneda);
            }

            ab.Fecha = abono.Fecha;
            ab.Monto = abono.Monto;
            ab.Moneda = abono.Moneda;
            db.SaveChanges();


            return NoContent();

        }

        // DELETE api/<AbonosPrepagoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            log.LogError($"Eliminar Id {id}");
            var abono = db.AbonosPrepago.Find(id); 
            if(abono == null)
            {
                return NotFound(id); 
            }
            db.AbonosPrepago.Remove(abono);
            db.SaveChanges();
            return Ok(); 
        }
    }
}
