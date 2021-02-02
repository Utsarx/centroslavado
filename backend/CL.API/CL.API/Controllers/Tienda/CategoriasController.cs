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
    [Route("api/[controller]")]
    [ApiController]
    public partial class CategoriasController : ControllerBase
    {
        protected readonly ContextoAplicacion db;
        protected readonly ILogger<CategoriasController> log; 
         
        public CategoriasController(ILogger<CategoriasController> logger, ContextoAplicacion contexto)
        {

            db = contexto;
            log = logger; 

        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return db.Categorias.ToList().OrderBy(x => x.Nombre).ToList(); 

        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetCategoria(Guid id)
        {
            log.LogError($"Id {id}"); 
            var catego = db.Categorias.Find(id); 
            if(catego == null)
            {
                return NotFound(id);  
            }
            return Ok(catego); 
           
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult<Guid> PostCategoria([FromBody] Categoria catego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            catego.Id = Guid.NewGuid();
            db.Categorias.Add(catego);
            db.SaveChanges();
            
            return Ok(catego.Id); 

        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult PutCategoria(Guid id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 

            }

            var catego = db.Categorias.Find(id); 
            if(catego == null)
            {
                return NotFound(); 
            }

            // LINQ

            var categotemp = db.Categorias.Where(
                xcategoria => xcategoria.Nombre == categoria.Nombre
                && xcategoria.Id != id).SingleOrDefault();

            if (categotemp != null)
            {
                return Conflict(categoria.Nombre); 
            }

            catego.Nombre = categoria.Nombre;
            db.SaveChanges();
            return NoContent(); 

        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCategoria(Guid id)
        {
            log.LogError($"Eliminar Id {id}");

            var catego = db.Categorias.Find(id); 

            if(catego == null)
            {
                return NotFound(); 
            }

            db.Categorias.Remove(catego);
            db.SaveChanges();
            return Ok(); 
        }
    }
}
