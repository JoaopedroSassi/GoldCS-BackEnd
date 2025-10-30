using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Models.Entities;


namespace src.Controllers
{
	[ApiController]
	[Route("api/order")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class OrderController : ControllerBase
	{
		private readonly ICreateOrderService _createOrderService;
		private readonly IListOrderService _listOrderService;
        private readonly INotificationService _notificationService;


        public OrderController(ICreateOrderService createOrderService,
			INotificationService notificationService,
			IListOrderService listOrderService)
		{
			_createOrderService = createOrderService;
			_notificationService = notificationService;
			_listOrderService = listOrderService;
		}

		[HttpPost]
		public async Task<IActionResult> InsertOrder([FromBody] OrderRequests.CreateOrder request)
		{
			
			await _createOrderService.Process(request);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Created();
		}

		[HttpGet]
		public async Task<IActionResult> ListOrders()
		{
			var orders = await _listOrderService.ListOrders();
            
			if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));
            
			return Ok(new BaseResponse<List<OrderResponse>>().CriarSucesso(orders));
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOrderByIdAsync(int id)
		{
			var response = await _listOrderService.ViewOrder(id);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<OrderResponse>().CriarSucesso(response));
        }

	}
}