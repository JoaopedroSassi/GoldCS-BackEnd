using GoldCS.API.Controllers;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace src.Controllers
{
	[ApiController]
	[Route("api/order")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class OrderController : MainController
	{
		private readonly ICreateOrderService _createOrderService;
		private readonly IListOrderService _listOrderService;


        public OrderController(
			ICreateOrderService createOrderService,
			IListOrderService listOrderService,
			INotificationService notificationService) : base(notificationService)
        {
			_createOrderService = createOrderService;
			_listOrderService = listOrderService;
		}

		[HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] OrderRequests.CreateOrder request)
		{			
			var response = await _createOrderService.Process(request);
			return CustomResponse(response);
		}

		[HttpGet]
        public async Task<IActionResult> ListOrders()
		{
			var response = await _listOrderService.ListOrders();
			return CustomResponse(response);
		}
        
        [HttpGet("{id:int}")]
		public async Task<IActionResult> GetOrderByIdAsync(int id)
		{
			var response = await _listOrderService.ViewOrder(id);
            return CustomResponse(response);
        }

    }
}