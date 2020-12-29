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
        [HttpGet("empresa/{idemp}")]
        public ActionResult<IEnumerable<AbonoPrepago>> GetPorEmpresa(Guid idemp)
        {
            return db.AbonosPrepago.Where(p=>p.EmpesaId == idemp).ToList().OrderBy(x => x.Fecha).ToList();
        }

        // GET api/<AbonosPrepagoController>/5
        [HttpGet("{id}")]
        public ActionResult<AbonoPrepago> Get(Guid id)
        {
            log.LogError($"Id {id}");
            var abono = db.AbonosPrepago.Find(id);
            if (abono == null)
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
