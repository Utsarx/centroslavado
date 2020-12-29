using CL.Modelo;
using CL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.API.Controllers.Empresas
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class EmpresasController : ControllerBase
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<EmpresasController> log;
       public EmpresasController(
            ILogger<EmpresasController> logger,
            ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }


        // GET: api/<EmpresasController>
        [HttpGet]
        public ActionResult<IEnumerable<EmpresaTransporte>> Get()
        {

    //    // GET: api/<EmpresasController>
        [HttpGet]
        public ActionResult<IEnumerable<EmpresaTransporte>> Get()
        {
            return db.Empresas.ToList().OrderBy(x => x.Nombre).ToList();
        }

    //    // GET api/Empresas/guid
        [HttpGet("{id}")]
        public ActionResult<EmpresaTransporte> Get(Guid id)
        {
            log.LogError($"Id {id}");
            var emp = db.Empresas.Find(id);
            if (emp == null)
            {
                return NotFound(id);
            }
            return Ok(emp);
        }

    //    // POST api/<EmpresasController>
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

    //    // PUT api/Empresas/guid
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

    //        // LINQ
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

    //    // DELETE api/<EmpresasController>/5
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


        //    [HttpPost("{idemp}/tipopago/{idpago}")]
        //        public ActionResult PostMetodoPagoEmpresa(Guid idemp, String idpago)
        //    {


        //        var empresa = db.Empresas.Find(idemp);
        //        if (empresa == null)
        //        {
        //            return NotFound();
        //        }

        //        var metpago = db.MedioPagos.Find(idpago);
        //        if (metpago == null)
        //        {
        //            return NotFound();
        //        }

        //        if (db.medioPagoEmpresas.Any(x => x.EmpresaId == idemp
        //        && x.MedioPagoId == idpago))
        //        {
        //            return Ok();
        //        }

        //        MedioPagoEmpresa m = new MedioPagoEmpresa() { 
        //         EmpresaId = idemp, MedioPagoId = idpago
        //        }; 

        //        db.medioPagoEmpresas.Add(m);
        //        db.SaveChanges();
        //        return Ok(); 

        //    }

        //    // DELETE api/<EmpresasController>/5
        //    [HttpDelete("{idemp}/tipopago/{idpago}")]
        //    public ActionResult DeleteMedioPagoEmpresa(Guid idemp, String idpago)
        //    {
        //        var emp = db.Set<MedioPagoEmpresa>().Find(idemp, idpago); 

        //        // var emp = db.medioPagoEmpresas.Find( idemp, idmp);

        //        if (emp == null)
        //        {
        //            return NotFound(emp);
        //             }

        //        db.medioPagoEmpresas.Remove(emp);
        //        db.SaveChanges();

        //        return NoContent();

        //    }




    }
}
