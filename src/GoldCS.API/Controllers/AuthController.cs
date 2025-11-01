using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoldCS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MainController
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly IRefreshTokenService _refreshTokenService; 


        public AuthController(IAuthenticationService authenticationService,
            IRefreshTokenService refreshTokenService,
            INotificationService notificationService) : base(notificationService)
        {
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.Process(request);
            return CustomResponse(response);

        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string request)
        {
            var response = await _refreshTokenService.Process(request);
            return CustomResponse(response);
        }
    }
}
