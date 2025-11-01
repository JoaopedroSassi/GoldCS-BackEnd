using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoldCS.API.Controllers
{
    public abstract class MainController : ControllerBase
    {
        private readonly INotificationService _notificationService; 

        protected MainController (INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult CustomResponse()
        {
            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));
            
            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult CustomResponse<T>(T result) where T : class
        {
            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<T>().CriarSucesso(result));
        }
    }
}
