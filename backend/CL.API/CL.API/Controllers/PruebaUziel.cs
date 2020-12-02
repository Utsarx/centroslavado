using CL.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaUzielController : ControllerBase
    {

        [HttpGet]
        public ActionResult Ejemplo()
        {
            Chofer c = new Chofer() { EmpresaId = Guid.Empty, Id = Guid.NewGuid(), Nombre = "Chofer de ejemplo" };
            return Ok(c);

        }
    }
}
