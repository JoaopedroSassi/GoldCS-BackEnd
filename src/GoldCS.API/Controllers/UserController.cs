using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldCS.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly ICreateUserService _createUserService;

        public UserController(INotificationService notificationService, ICreateUserService createUserService) : base(notificationService)  
        { 
            _createUserService = createUserService;
        }
        
        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _createUserService.Process(request);
            return CustomResponse();
        }
    }
}
