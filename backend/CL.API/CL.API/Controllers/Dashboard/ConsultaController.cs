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
    public class ConsultaController : ControllerBase
    {
        protected readonly ContextoAplicacion db;
        protected readonly ILogger<ConsultaController> log;
        public ConsultaController(
             ILogger<ConsultaController> logger,
             ContextoAplicacion contexto)
        {
            db = contexto;
            log = logger;
        }


    }
}
