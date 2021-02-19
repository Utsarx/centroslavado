using CL.API.Modelos;
using CL.API.Servicios;
using CL.Modelo;
using CL.Modelo.Contabilidad;
using CL.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoventaController : ControllerBase
    {

        protected readonly ContextoAplicacion db;
        protected readonly ILogger<PuntoventaController> log;
        public PuntoventaController(
             ILogger<PuntoventaController> logger,
             ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }


        [HttpGet("configuracion")]
        public async Task<ActionResult<List<ConfiguracionVentaeCentroLavado>>> GetCentrosLavado()
        {
            Guid UserId = Guid.Parse("43955a9c-af92-441a-883d-851c3fec8767");
            ServicioConfiguracionPuntoVenta servicio = new ServicioConfiguracionPuntoVenta(db);

            servicio.MisCentros(UserId);

            await Task.Delay(1);
            return Ok(servicio.MisCentros(UserId));
        }


        [HttpGet("empresas")]
        public async Task<ActionResult<List<ParOrdenado>>> GetCentrosLavado([FromQuery] string buscar)
        {
            await Task.Delay(1);
            List<EmpresaTransporte> lista = db.Empresas.Where(x => x.Nombre.StartsWith(buscar)).OrderBy(x => x.Nombre).ToList();
            List<ParOrdenado> pares = new List<ParOrdenado>();
            lista.ForEach(x =>
               {
                   pares.Add(new ParOrdenado()
                   {

                       Id = x.Id.ToString(),
                       Index = 0,
                       Texto = x.Nombre
                   });
               });

            return Ok(pares);
        }

        [HttpGet("vehiculos/{idempresa}")]
        public async Task<ActionResult<List<ParOrdenado>>> GetVehiculosEmpresa(Guid idempresa)
        {
            await Task.Delay(1);
            List<Tractor> tractores = db.Tractores.Where(x => x.EmpresaId == idempresa).ToList();
            List<Caja> cajas = db.Cajas.Where(x => x.EmpresaId == idempresa).ToList();

            List<ParOrdenado> pares = new List<ParOrdenado>();
            tractores.ForEach(x =>
            {
                pares.Add(new ParOrdenado()
                {

                    Id = x.Id.ToString(),
                    Index = 0,
                    Texto = x.Noeconomico
                });
            });

            cajas.ForEach(x =>
            {
                pares.Add(new ParOrdenado()
                {

                    Id = x.Id.ToString(),
                    Index = 0,
                    Texto = x.NoEconomico
                });
            });

            pares.Add(new ParOrdenado()
            {
                Id = Guid.NewGuid().ToString(),
                Index = 0,
                Texto = "Demo"
            });

            pares.Add(new ParOrdenado()
            {
                Id = Guid.NewGuid().ToString(),
                Index = 0,
                Texto = "Demo 2"
            });

            return Ok(pares);
        }


        [HttpPost]
        public async Task<ActionResult> CreaPago([FromBody] List<CobroServicio> datos)
        {
            foreach(var d in datos)
            {
                d.Fecha = DateTime.UtcNow;
            }

            await Task.Delay(1);
            return Ok();
        }



    }
}
