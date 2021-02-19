using CL.Modelo;
using CL.Repositorio;
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
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        protected readonly ContextoAplicacion db;
        protected readonly ILogger<EmpleadosController> log;
        public EmpleadosController(
             ILogger<EmpleadosController> logger,
             ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }

        // GET: api/CentroLavadoController
        [HttpGet("centro/{clid}", Name = "GetEmpleadosCentroLavado")]
        public ActionResult<IEnumerable<Empleado>> Get(Guid clid)
        {
            //return db.Empleados.ToList().OrderBy(x => x.Nombre).ToList();

            //return Ok(new List<Empleado>());

            Console.WriteLine($"{clid}");
            List<Empleado> lista = new List<Empleado>();
            var ecl = db.EmpleadosCentroLavado.Where(x => x.CentroLavadoId == clid)
                .ToList();

            Console.WriteLine($"{ecl.Count}");

            foreach (var e in ecl)
            {
                var emp = db.Empleados.Where(x => x.Id == e.EmpleadoId).FirstOrDefault();
                lista.Add(new Empleado()
                {
                    Id = emp.Id,
                    Nombre = emp.Nombre, NombreUsuario = emp.NombreUsuario, 
                    Hash = emp.Hash, Salt = emp.Salt, 
                    UsuarioSistema = emp.UsuarioSistema,
                    RefreshTokens = emp.RefreshTokens, 
                    UltimoAcceso = emp.UltimoAcceso,
                    Activo = emp.Activo, 
                     

                }) ;

            }

            return Ok(
                
                lista

                );
        }

        // GET api/Empleados/5
        [HttpGet("{id}", Name = "GetEmpleado")]
        public ActionResult GetEmpleado(Guid id)
        {
            var emp = db.Empleados.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        // POST api/centrolavado
        [HttpPost(Name = "PostEmpleado")]
        public ActionResult<Guid> PostEmpleado([FromBody] Empleado empleado)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (empleado.UsuarioSistema)
            {
                if (string.IsNullOrEmpty(empleado.Hash) ||
                    string.IsNullOrEmpty(empleado.NombreUsuario))
                {
                    return BadRequest("Debe icluir una contraseña en el campo Hash y un nombre de usuario");
                } else
                {
                    empleado.Salt = empleado.Hash;
                }

                if (db.Empleados.Any(x => x.NombreUsuario.ToLower() == empleado.NombreUsuario.ToLower()))
                {
                    return BadRequest("El nombre del usuario ya esta en uso");
                }
            }

            empleado.Activo = true;
            empleado.Id = Guid.NewGuid();
            db.Empleados.Add(empleado);
            db.SaveChanges();
            return Ok(empleado.Id);

        }


        // POST api/centrolavado
        [HttpPost("centro/{idcentro}", Name = "PostEmpleadoCentro")]
        public ActionResult<Guid> PostEmpleadoPorCentro(Guid idcentro, [FromBody] Empleado empleado)
        {
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(empleado));
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        Console.WriteLine(modelError.ErrorMessage);
                    }

                }
                return BadRequest();
               
            }
            
            if (empleado.UsuarioSistema)
            {
                if (string.IsNullOrEmpty(empleado.Hash) ||
                    string.IsNullOrEmpty(empleado.NombreUsuario))
                {
                    return BadRequest("Debe icluir una contraseña en el campo Hash y un nombre de usuario");
                }
                else
                {
                    empleado.Salt = empleado.Hash;
                }

                if (db.Empleados.Any(x => x.NombreUsuario.ToLower() == empleado.NombreUsuario.ToLower()))
                { 
                    return BadRequest("El nombre del usuario ya esta en uso");
                }
            }

            empleado.Activo = true;
            empleado.Id = Guid.NewGuid();
            db.Empleados.Add(empleado);
            

            db.EmpleadosCentroLavado.Add(new EmpleadoCentroLavado()
            {
                CentroLavadoId = idcentro, EmpleadoId = empleado.Id
            });
            db.SaveChanges();
            return Ok(empleado.Id);

        }


        // PUT api/<CentroLavadoController>/5
        [HttpPut("{id}", Name = "PutEmpleado")]
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
        [HttpDelete("{id}", Name = "DeleteEmpleado")]
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
