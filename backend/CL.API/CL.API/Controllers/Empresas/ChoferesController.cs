using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.Empresas
{/// <summary>
 /// Administarción de choferes 
 /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public partial class ChoferesController : ControllerBase 
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<ChoferesController> log;
        public ChoferesController(
             ILogger<ChoferesController> logger,
             ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }

        // GET: api/EmpresasController
        [HttpGet("empresa/{empid}", Name = "GetChoferesPorEmpresa")]
        public ActionResult<IEnumerable<Chofer>> GetChoferes(Guid empid)
        {
            return Ok(
                db.Choferes.Where(x => x.EmpresaId == empid )
                .ToList().OrderBy(x => x.Nombre).ToList()
                );
        }


        // GET api/<EmpresasController>/5
        [HttpGet("{id}", Name = "GetChofer")]
        public ActionResult GetChofer(Guid id)
        {
            var chof = db.Choferes.Find(id);
            if (chof == null)
            {
                return NotFound();
            }
            return Ok(chof);
        }

        // POST api/Empresas/{empid}
        [HttpPost( Name = "PostChofer")]
        public ActionResult<Guid> PostChofer([FromBody] Chofer chof)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Empresa = db.Empresas.Find(chof.EmpresaId);
            if (Empresa == null)
            {
                return NotFound();
            }

            chof.Id = Guid.NewGuid();
            chof.EmpresaId = chof.EmpresaId;
            db.Choferes.Add(chof);
            db.SaveChanges();
            return Ok(chof.Id);
        }

        // PUT api/<EmpresasController>/5
        [HttpPut("{id}", Name = "PutChofer")]
        public ActionResult PutChofer(Guid id, [FromBody] Chofer chof)
        {
            if (chof.Id != id) return BadRequest();

            if (!ModelState.IsValid)
           {
                return BadRequest();
            }

            var chofer = db.Choferes.Find(id);
            if (chofer == null)
            {
                return NotFound(id);
            }

            chofer.Nombre = chof.Nombre;
            db.SaveChanges();

            return NoContent();
        }

        // DELETE api/EmpresasController>/5
        [HttpDelete("{id}", Name = "DeleteChofer")]
        public ActionResult DeleteChofer(Guid id)

        {
            var chof = db.Choferes.Find(id);
            if (chof == null)
            {
                return NotFound(id);
            }

            db.Choferes.Remove(chof);
            db.SaveChanges();
            return NoContent();

        }
    }
}

