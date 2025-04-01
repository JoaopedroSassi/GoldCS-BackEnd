using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GoldCS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(LoginResponse), 412)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(new LoginResponse().GerarCritica(Criticas.ERROINTERNO));

            var response = await _authenticationService.Authenticate(request);

            if(!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
