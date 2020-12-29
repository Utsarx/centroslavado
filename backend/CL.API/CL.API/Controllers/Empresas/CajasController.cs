using CL.Modelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.Empresas
{/// <summary>
/// Administración de cajas 
/// </summary>
    public partial class EmpresasController : ControllerBase
    {
    //    // GET: api/EmpresasController
        [HttpGet("{empid}/cajas", Name = "GetCajas")]
        public ActionResult<IEnumerable<EmpresaTransporte>> GetCajas(Guid empid)
        {
            return Ok(
                db.Cajas.Where(x => x.EmpresaId == empid)
               .ToList().OrderBy(x => x.NoEconomico).ToList()
               );
        }


    //    // GET api/<EmpresasController>/5
        [HttpGet("cajas/{id}", Name = "GetCaja")]
        public ActionResult GetCaja(Guid id)
        {
            var caja = db.Cajas.Find(id);
            if (caja == null)
           {
               return NotFound();
            }
            return Ok(caja);
        }

    //    // POST api/Empresas/{empid}
        [HttpPost("{empid}/cajas", Name = "PostCaja")]
        public ActionResult<Guid> PostCaja(Guid empid, [FromBody] Caja caja)
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

            caja.Id = Guid.NewGuid();
            caja.EmpresaId = empid;
            db.Cajas.Add(caja);
            db.SaveChanges();
            return Ok(caja.Id);
        }

    //    // PUT api/<EmpresasController>/5
        [HttpPut("cajas/{id}", Name = "PutCaja")]
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

    //    // DELETE api/EmpresasController>/5
        [HttpDelete("cajas/{id}", Name = "DeleteCaja")]
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
