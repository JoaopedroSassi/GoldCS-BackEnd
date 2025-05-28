using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldCS.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ICreateUserService _createUserService;

        public UserController(INotificationService notificationService, ICreateUserService createUserService) 
        { 
            _notificationService = notificationService;
            _createUserService = createUserService;
        }
        
        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _createUserService.Process(request);

            if (_notificationService.HasNotifications())
            {
                return StatusCode(412, new BaseResponse().CustomCritics(_notificationService.GetNotifications()));
            }

            return Ok();
        }
    }
}
