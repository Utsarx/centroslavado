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
    /// Administarción de tractores 
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public partial class TractoresController : ControllerBase
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<TractoresController> log;
        public TractoresController(
             ILogger<TractoresController> logger,
             ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }

        // GET: Lista de tractores de la empresa
        [HttpGet("empresa/{id}", Name = "GetTractores")]
        public ActionResult<IEnumerable<EmpresaTransporte>> GetTractoresEmpresa(Guid id)
        {
            return Ok(
                db.Tractores.Where(x => x.EmpresaId == id)
                .ToList().OrderBy(x => x.Noeconomico).ToList()
                );
        }

  
        // GET api/<TractoresController>/5
        [HttpGet("{id}", Name = "GetTractor")]
        public ActionResult GetTractor(Guid id)
        {
            var trac = db.Tractores.Find(id);
            if (trac == null)
            {
                return NotFound();
            }
            return Ok(trac);
        }

        // POST api/Empresas/{empid}
        [HttpPost(Name = "PostTractor")]
        public ActionResult<Guid> PostTractor([FromBody] Tractor trac)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Empresa = db.Empresas.Find(trac.EmpresaId);
            if (Empresa == null)
            {
                return NotFound();
            }

            trac.Id = Guid.NewGuid();
            db.Tractores.Add(trac);
            db.SaveChanges();
            return Ok(trac.Id);
        }

        // PUT api/<EmpresasController>/5
        [HttpPut("{id}", Name = "PutTractor")]
        public ActionResult PutTractor(Guid id, [FromBody] Tractor trac)
        {
            if (trac.Id != id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tract = db.Tractores.Find(id);
            if (tract == null)
            {
                return NotFound(id);
            }

            tract.Noeconomico = trac.Noeconomico;
            db.SaveChanges();

            return NoContent();
        }

        // DELETE api/EmpresasController>/5
        [HttpDelete("{id}", Name = "DeleteTractor")]
        public ActionResult DeleteTractor(Guid id)

        {
            var trac = db.Tractores.Find(id);
            if (trac == null)
            {
                return NotFound(id);
            }

            db.Tractores.Remove(trac);
            db.SaveChanges();
            return NoContent();

        }
    }
}
