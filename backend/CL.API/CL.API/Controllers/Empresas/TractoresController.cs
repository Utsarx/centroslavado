using CL.Modelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.Empresas
{
 /// <summary>
 /// Administarción de tractores 
 /// </summary>
   public partial class EmpresasController : ControllerBase
    {
   //     // GET: api/TractoresController
       [HttpGet("{empid}/tractores", Name = "GetTractores")]
        public ActionResult<IEnumerable<EmpresaTransporte>> GetTractores(Guid empid)
        {
            return Ok(
                db.Tractores.Where(x => x.EmpresaId == empid)
                .ToList().OrderBy(x => x.Noeconomico).ToList()
                );
        }

   //     // GET api/<TractoresController>/5
        [HttpGet("tractores/{id}", Name = "GetTractor")]
        public ActionResult GetTractor(Guid id)
        {
            var trac = db.Tractores.Find(id);
            if (trac== null)
            {
                return NotFound();
            }
           return Ok(trac);
        }

   //     // POST api/Empresas/{empid}
       [HttpPost("{empid}/tractores", Name = "PostTractor")]
       public ActionResult<Guid> PostTractor(Guid empid, [FromBody] Tractor trac)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Empresa = db.Empresas.Find(empid);
            if (Empresa == null)
            {
               return NotFound();
           }

            trac.Id = Guid.NewGuid();
            trac.EmpresaId = empid;
            db.Tractores.Add(trac);
            db.SaveChanges();
            return Ok(trac.Id);
        }

   //     // PUT api/<EmpresasController>/5
        [HttpPut("tractores/{id}", Name = "PutTractor")]
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

   //     // DELETE api/EmpresasController>/5
        [HttpDelete("tractores/{id}", Name = "DeleteTractor")]
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
