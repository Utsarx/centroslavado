using CL.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.CentrosLavado
{

    /// <summary>
    /// Administarción de empleados
    /// </summary>
    public partial class CentrosLavadoController : ControllerBase
    {

        // GET: api/CentroLavadoController
        [HttpGet("{clid}/empleados", Name = "GetEmpleados")]
        public ActionResult<IEnumerable<CentroLavado>> GetEmpleados(Guid clid)
        {
            return Ok(
                db.Empleados.Where(x => x.CentroLavadoId == clid)
                .ToList().OrderBy(x => x.Nombre).ToList()
                );
        }

        // GET api/<CentroLavadoController>/5
        [HttpGet("empleados/{id}", Name = "GetEmpleado")]
        public ActionResult GetEmpleado(Guid id)
        {
            var emp = db.Empleados.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        // POST api/centrolavado/{clid}
        [HttpPost("{clid}/empleados", Name = "PostEmpleado")]
        public ActionResult<Guid> PostEmpleado(Guid clid, [FromBody] Empleado empleado)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var centro = db.CentrosLavado.Find(clid);
            if (centro == null)
            {
                return NotFound();
            }

            empleado.Id = Guid.NewGuid();
            empleado.CentroLavadoId = clid;
            db.Empleados.Add(empleado);
            db.SaveChanges();
            return Ok(empleado.Id);

        }

        // PUT api/<CentroLavadoController>/5
        [HttpPut("empleados/{id}", Name = "PutEmpleado")]
        public ActionResult PutEmpleado(Guid id, [FromBody] Empleado empleado)
        {
            if(empleado.Id != id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var emp = db.Empleados.Find(id);
            if (emp == null)
            {
                return NotFound(id);
            }

            emp.Nombre = empleado.Nombre;
            db.SaveChanges();


            return NoContent();
        }

        // DELETE api/<CentroLavadoController>/5
        [HttpDelete("empleados/{id}", Name = "DeleteEmpleado")]
        public ActionResult DeleteEmpleado(Guid id)

        {
            var emp = db.Empleados.Find(id);
            if (emp == null)
            {
                return NotFound(id);
            }

            db.Empleados.Remove(emp);
            db.SaveChanges();
            return NoContent();

        }
    }
}
