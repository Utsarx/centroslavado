using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.Empresas
{
    /// <summary>
    /// Administración de cajas 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public partial class CajasController : ControllerBase
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<EmpresasController> log;
        public CajasController(
             ILogger<EmpresasController> logger,
             ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }



        // GET: api/EmpresasController
        [HttpGet("empresa/{empid}", Name = "GetCajas")]
        public ActionResult<IEnumerable<EmpresaTransporte>> GetCajas(Guid empid)
        {
            return Ok(
                db.Cajas.Where(x => x.EmpresaId == empid)
               .ToList().OrderBy(x => x.NoEconomico).ToList()
               );
        }


        // GET api/<EmpresasController>/5
        [HttpGet("{id}", Name = "GetCaja")]
        public ActionResult GetCaja(Guid id)
        {
            var caja = db.Cajas.Find(id);
            if (caja == null)
            {
                return NotFound();
            }
            return Ok(caja);
        }

        // POST api/Empresas/{empid}
        [HttpPost(Name = "PostCaja")]
        public ActionResult<Guid> PostCaja([FromBody] Caja caja)
        {
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(caja) );

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Empresa = db.Empresas.Find(caja.EmpresaId);
            if (Empresa == null)
            {
                return NotFound();
            }

            caja.Id = Guid.NewGuid();
            db.Cajas.Add(caja);
            db.SaveChanges();
            return Ok(caja.Id);
        }

        // PUT api/<EmpresasController>/5
        [HttpPut("{id}", Name = "PutCaja")]
        public ActionResult PutCaja(Guid id, [FromBody] Caja caja)
        {
            if (caja.Id != id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cajita = db.Cajas.Find(id);
            if (cajita == null)
            {
                return NotFound(id);
            }

            cajita.NoEconomico = caja.NoEconomico;
            db.SaveChanges();

            return NoContent();
        }

        // DELETE api/EmpresasController>/5
        [HttpDelete("{id}", Name = "DeleteCaja")]
        public ActionResult DeleteCaja(Guid id)

        {
            var caja = db.Cajas.Find(id);
            if (caja == null)
            {
                return NotFound(id);
            }

            db.Cajas.Remove(caja);
            db.SaveChanges();
            return NoContent();

        }
    }
}
