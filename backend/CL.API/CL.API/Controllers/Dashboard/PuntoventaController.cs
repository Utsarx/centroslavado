using CL.Modelo;
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
        public  async Task<ActionResult<List<ConfiguracionVentaeCentroLavado>>> GetCentrosLavado()
        {
            await Task.Delay(1);
            return Ok(DatosDemo.CentrosDemo());
        }


    }
}
