using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.API.Controllers.CentrosLavado
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CentrosLavadoController : ControllerBase
    {
        protected readonly ContextoAplicacion db;
        protected readonly ILogger<CentrosLavadoController> log;

        //Constructor 
        public CentrosLavadoController(
            ILogger<CentrosLavadoController> logger, 
            ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger; 

        }

        // GET: api/CentroLavadoController
        [HttpGet(Name = "GetCentrosLavado")]
        public ActionResult <IEnumerable<CentroLavado>> GetCentrosLavado()
        {
            return db.CentrosLavado.ToList().OrderBy(x => x.Nombre).ToList(); 
        }

        // GET api/<CentroLavadoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            log.LogError($"Id :{id}");
            var centro = db.CentrosLavado.Find(id); 
            if(centro == null)
            {
                return NotFound(); 
            }
            return Ok(centro); 
        }

        // POST api/CentroLavadoController/guid
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] CentroLavado centro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            centro.Id = Guid.NewGuid();
            db.CentrosLavado.Add(centro);
            db.SaveChanges();
            return Ok(centro.Id); 
            
        }

        // PUT api/<CentroLavadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] CentroLavado centro)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cent = db.CentrosLavado.Find(id); 
            if(cent == null)
            {
                return NotFound(id); 
            }

            //LINQ
            var centroTemp = db.CentrosLavado.Where(
                xcentro => xcentro.Nombre == centro.Nombre
                && xcentro.Id != id).SingleOrDefault(); 
            if(centroTemp != null)
            {
                return Conflict(centro.Nombre); 
            }

            cent.Nombre = centro.Nombre;

            db.SaveChanges();


            return NoContent();
        }

        // DELETE api/<CentroLavadoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)

        {
            log.LogError($"Eliminar {id}");
            var cent = db.CentrosLavado.Find(id);
            if(cent == null)
            {
                return NotFound(id);
            }

            db.CentrosLavado.Remove(cent);
            db.SaveChanges();
            return NoContent(); 

        }

        [HttpPut("{idcl}/{idemp}" , Name = "PutCambioCentroLavado")]
        public ActionResult PutCambioCentroLavado(Guid idcl, Guid idemp)
        {
            var cent = db.CentrosLavado.Find(idcl);
            if (cent == null)
            {
                return NotFound(idcl);
            }

            var emp = db.Empleados.Find(idemp);
            if (emp == null)
            {
                return NotFound(idemp);
            }

            db.SaveChanges();

            return Ok();
        }

    }
}
