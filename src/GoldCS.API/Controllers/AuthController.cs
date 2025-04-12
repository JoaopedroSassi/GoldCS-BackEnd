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

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(412,new BaseResponse<LoginResponse>().GenerateCritic(Criticas.ERROINTERNO));

            var response = await _authenticationService.Authenticate(request);

            if(!response.Success) return StatusCode(412,response);

            return Ok(response);
        }
    }
}
