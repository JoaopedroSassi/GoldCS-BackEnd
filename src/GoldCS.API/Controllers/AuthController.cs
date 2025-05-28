using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
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
        private readonly IRefreshTokenService _refreshTokenService; 
        private readonly INotificationService _notificationService;


        public AuthController(IAuthenticationService authenticationService,
            IRefreshTokenService refreshTokenService,
            INotificationService notificationService)
        {
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;
            _notificationService = notificationService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.Process(request);

            if (_notificationService.HasNotifications()){
                return StatusCode(412, new BaseResponse().CustomCritics(_notificationService.GetNotifications()));
            }

            return Ok(new BaseResponse<LoginResponse>().CriarSucesso(response));
        }

        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<LoginResponse>), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> RefreshToken([FromBody] string request)
        {
            var response = await _refreshTokenService.Process(request);

            if (_notificationService.HasNotifications())
            {
                return StatusCode(412, new BaseResponse().CustomCritics(_notificationService.GetNotifications()));
            }

            return Ok(new BaseResponse<LoginResponse>().CriarSucesso(response));
        }
    }
}
