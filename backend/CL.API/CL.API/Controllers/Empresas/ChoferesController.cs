using CL.Modelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.Empresas
{/// <summary>
 /// Administarción de choferes 
 /// </summary>
    public partial class EmpresasController : ControllerBase 

    {
        //// GET: api/EmpresasController
        //[HttpGet("{empid}/choferes", Name = "GetChoferes")]
        //public ActionResult<IEnumerable<EmpresaTransporte>> GetChoferes(Guid empid)
        //{
        //    return Ok(
        //        db.Choferes.Where(x => x.EmpresaId == empid )
        //        .ToList().OrderBy(x => x.Nombre).ToList()
        //        );
        //}


        //// GET api/<EmpresasController>/5
        //[HttpGet("choferes/{id}", Name = "GetChofer")]
        //public ActionResult GetChofer(Guid id)
        //{
        //    var chof = db.Choferes.Find(id);
        //    if (chof == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(chof);
        //}

        //// POST api/Empresas/{empid}
        //[HttpPost("{empid}/choferes", Name = "PostChofer")]
        //public ActionResult<Guid> PostChofer(Guid empid, [FromBody] Chofer chof)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var Empresa = db.Empresas.Find(empid);
        //    if (Empresa == null)
        //    {
        //        return NotFound();
        //    }

        //    chof.Id = Guid.NewGuid();
        //    chof.EmpresaId = empid;
        //    db.Choferes.Add(chof);
        //    db.SaveChanges();
        //    return Ok(chof.Id);
        //}

        //// PUT api/<EmpresasController>/5
        //[HttpPut("choferes/{id}", Name = "PutChofer")]
        //public ActionResult PutChofer(Guid id, [FromBody] Chofer chof)
        //{
        //    if (chof.Id != id) return BadRequest();

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var chofer = db.Choferes.Find(id);
        //    if (chofer == null)
        //    {
        //        return NotFound(id);
        //    }

        //    chofer.Nombre = chof.Nombre;
        //    db.SaveChanges();

        //    return NoContent();
        //}

        //// DELETE api/EmpresasController>/5
        //[HttpDelete("choferes/{id}", Name = "DeleteChofer")]
        //public ActionResult DeleteChofer(Guid id)

        //{
        //    var chof = db.Choferes.Find(id);
        //    if (chof == null)
        //    {
        //        return NotFound(id);
        //    }

        //    db.Choferes.Remove(chof);
        //    db.SaveChanges();
        //    return NoContent();

        //}
    }
}
