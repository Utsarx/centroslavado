using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.API.Controllers.Tienda
{

   
    public partial class CategoriasController : ControllerBase
    {
     
        // GET: api/<PreciosController>
        [HttpGet("{servid}/precios", Name = "GetPrecios")]
        public ActionResult <IEnumerable<Precio>> GetPrecios(Guid servid) 
        {
            return Ok(db.Precios.Where(x => x.ServicioId == servid).ToList().OrderBy(x => x.Id).ToList()); 
        }

        // GET api/<PreciosController>/5
        [HttpGet("precios/{id}", Name = "GetPrecio")]
        public ActionResult Get(Guid id)
        {
            log.LogError($"Id{id}");
            var precio = db.Precios.Find(id);
            if (precio == null)
            {
                return NotFound(id); 
            }
            return Ok(precio); 
        }

        // POST api/<PreciosController>
        [HttpPost("servicios/{servid}/precios", Name = "PostPrecio")]
        public ActionResult<Guid> PostPrecio(Guid servid, [FromBody] Precio precio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var servicio = db.Servicios.Find(servid);

            if (servicio == null)
            {
                return NotFound(servid);
            }

            precio.Id = Guid.NewGuid();
            precio.ServicioId = servid; 
            db.Precios.Add(precio);
            db.SaveChanges();
            return Ok(precio.Id); 
        }

        // PUT api/<PreciosController>/5
        [HttpPut("precios/{id}")]
        public ActionResult Put(Guid id, [FromBody] Precio precio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            var pre = db.Precios.Find(id); 
            if(pre == null)
            {
                return NotFound(id); 
            }

            //LINQ 

            var preciotemp = db.Precios.Where(
                xprecio => xprecio.Descripcion == precio.Descripcion
                && xprecio.Id != id).SingleOrDefault(); 

            if(preciotemp != null)
            {
                return Conflict(precio.Descripcion); 
            }

            preciotemp = db.Precios.Where(
                xprecio => xprecio.Monto == precio.Monto
                && xprecio.Id != id).SingleOrDefault(); 
            if(preciotemp != null)
            {
                return Conflict(precio.Monto);
            }

            pre.Descripcion = precio.Descripcion;
            pre.Monto = precio.Monto;
            db.SaveChanges();
            return NoContent(); 
        }

        // DELETE api/<PreciosController>/5
        [HttpDelete("precios/{id}")]
        public ActionResult Delete(Guid id)
        {
            log.LogError($"Eliminar Id{id}");
            var precio = db.Precios.Find(id); 
            if(precio == null)
            {
                return NotFound(id); 
            }
            db.Precios.Remove(precio);
            db.SaveChanges();
            return Ok(); 
        }
    }
}
