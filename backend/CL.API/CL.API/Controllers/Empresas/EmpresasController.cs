﻿using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.API.Controllers.Empresas
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {

        private readonly ContextoAplicacion db;
        private readonly ILogger<EmpresasController> log;
        public EmpresasController(
            ILogger<EmpresasController> logger,
            ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }

        // Patron CRUD 
        // Insertar	---> HttpPost
        // Actualizar	---> HttpPut
        // Eliminar	---> HttpDelete
        // Leer 		---> HttpGet


        // GET: api/<EmpresasController>
        [HttpGet]
        public ActionResult<IEnumerable<EmpresaTransporte>> Get()
        {
            return db.Empresas.ToList().OrderBy(x => x.Nombre).ToList(); 
        }

        // GET api/Empresas/guid
        [HttpGet("{id}")]
        public ActionResult<EmpresaTransporte> Get(Guid id)
        {
            log.LogError($"Id {id}");
            var emp = db.Empresas.Find(id);
            if(emp==null)
            {
                return NotFound(id);
            }
            return Ok(emp);
        }

        // POST api/<EmpresasController>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] EmpresaTransporte empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            empresa.Id = Guid.NewGuid();
            db.Empresas.Add(empresa);
            db.SaveChanges();

            return Ok(empresa.Id);

        }

        // PUT api/Empresas/guid
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] EmpresaTransporte empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var emp = db.Empresas.Find(id);
            if (emp == null)
            {
                return NotFound(id);
            }

            // LINQ
            var empresaTemp = db.Empresas.Where(
                xempresa => xempresa.Nombre == empresa.Nombre
                && xempresa.Id != id
                ).SingleOrDefault();

            if (empresaTemp != null)
            {
                return Conflict(empresa.Nombre);
            }

            empresaTemp = db.Empresas.Where(
                xempresa => xempresa.RFC == empresa.RFC
                && xempresa.Id != id
                ).SingleOrDefault();

            if (empresaTemp != null)
            {
                return Conflict(empresa.RFC);
            }


            emp.Nombre = empresa.Nombre;
            emp.RFC = empresa.RFC;

            db.SaveChanges();


            return NoContent();
        }

        // DELETE api/<EmpresasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            log.LogError($"Eliminar Id {id}");
            var emp = db.Empresas.Find(id);
            if (emp == null)
            {
                return NotFound(id);
            }

            db.Empresas.Remove(emp);
            db.SaveChanges();

            return NoContent();

        }
    }
}
