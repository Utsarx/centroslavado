using CL.API.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CL.API.Controllers.Autenicacion
{
    [ApiController]
    [Route("[controller]")]
    public class TokensController : ControllerBase
    {
        private readonly ILogger<TokensController> _logger;
        private readonly UserService _userService;

        public TokensController(ILogger<TokensController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("accesstoken", Name = "login")]
        public IActionResult Login([FromBody] Authentication auth)
        {
            try
            {
                var result = _userService.Login(auth);
                if(result == null)
                {
                    return BadRequest(auth);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize(AuthenticationSchemes = "refresh")]
        [HttpPut("accesstoken", Name = "refresh")]
        public IActionResult Refresh()
        {
            Claim refreshtoken = User.Claims.FirstOrDefault(x => x.Type == "refresh");
            Claim username = User.Claims.FirstOrDefault(x => x.Type == "username");

            try
            {
                return Ok(_userService.Refresh(username, refreshtoken));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
