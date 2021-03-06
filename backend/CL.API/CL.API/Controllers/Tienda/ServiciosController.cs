﻿using CL.Modelo;
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
    public partial class ServiciosController : ControllerBase
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<CategoriasController> log;

        public ServiciosController(ILogger<CategoriasController> logger, ContextoAplicacion contexto)
        {

            db = contexto;
            log = logger;

        }
        // GET: api/<ServiciosController>
        [HttpGet("categoria/{categoid}", Name = "GetServicios")]
        public ActionResult <IEnumerable<Servicio>> GetServicios(Guid categoid)
        {
            return Ok(db.Servicios.Where(x => x.CategoriaId == categoid).ToList().OrderBy(x => x.Nombre)
                .ToList()); 
               
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}", Name = "GetServicio")]
        public ActionResult<Servicio> GetServicio(Guid id)
        {
            log.LogError($"Id{id}");
            var serv = db.Servicios.Find(id);
            if (serv == null)
            {
                return NotFound(id);
            }
            return Ok(serv); 
        }
        // POST api/<ServiciosController>
        [HttpPost(Name = "PostServicio")]
        public ActionResult<Guid> PostServicio([FromBody] Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            var categoria = db.Categorias.Find(servicio.CategoriaId);
            if (categoria == null)
            {
                return NotFound();
            }

            servicio.Id = Guid.NewGuid();
            servicio.CategoriaId = servicio.CategoriaId; 
            db.Servicios.Add(servicio);
            db.SaveChanges();
            return Ok(servicio.Id); 

        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public ActionResult PutServicio(Guid id, [FromBody] Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var serv = db.Servicios.Find(id);
            if (serv == null)
            {
                return NotFound();
            }

            //LINQ
            var serviciotemp = db.Servicios.Where(
                xservicio => xservicio.Clave == servicio.Clave
                && xservicio.Id != id).SingleOrDefault();

            if (serviciotemp != null)
            {
                return Conflict(servicio.Clave);
            }

            serviciotemp = db.Servicios.Where(
                xservicio => xservicio.Nombre == servicio.Nombre
                && xservicio.Id != id).SingleOrDefault();
            if (serviciotemp !=null)
            {
                return Conflict(servicio.Nombre); 
            }

            serv.Clave = servicio.Clave;
            serv.Nombre = servicio.Nombre;
            db.SaveChanges();
            return NoContent(); 

        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteServicio(Guid id)
        {
            var serv = db.Servicios.Find(id);
            if (serv == null)
            {
                return NotFound();
            }
            db.Servicios.Remove(serv);
            db.SaveChanges();
            return Ok(); 
        }
    }
}
