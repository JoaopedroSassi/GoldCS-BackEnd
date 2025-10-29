using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace src.Controllers
{
	[ApiController]
	[Route("api/order")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class OrderController : ControllerBase
	{
		private readonly ICreateOrderService _createOrderService;
        private readonly INotificationService _notificationService;


        public OrderController(ICreateOrderService createOrderService,
			INotificationService notificationService)
		{
			_createOrderService = createOrderService;
			_notificationService = notificationService;
		}

		[HttpPost]
		public async Task<IActionResult> InsertOrder([FromBody] OrderRequests.CreateOrder request)
		{
			
			await _createOrderService.Process(request);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Created();
		}

		//[HttpGet]
  //      public async Task<ActionResult<IEnumerable<OrderDetailsDTO>>> GetOrdersAsync([FromQuery] QueryPaginationParameters paginationParameters)
  //      {
  //          var orders = await _createOrderService.GetAllOrdersAsync(paginationParameters);
  //          Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new PaginationReturn(orders.TotalCount, orders.PageSize, orders.CurrentPage, orders.TotalPages, orders.hasNext, orders.hasPrevious)));
  //          ResponseUtil respUtil = new ResponseUtil(true, orders);
  //          return Ok(respUtil);
  //      }

  //      [HttpGet("{id:int}")]
		//public async Task<ActionResult<OrderDetailsDTO>> GetOrderByIdAsync(int id)
		//{
		//	if (id <= 0)
		//		ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

		//	var orderId = await _createOrderService.GetOrderByIdAsync(id);

		//	ResponseUtil respUtil = new ResponseUtil(true, orderId); 
		//	return Ok(respUtil);
		//}


		//[Authorize(Roles = "admin")]
		//[HttpDelete("{id:int}")]
		//public async Task<ActionResult<string>> DeleteOrder([FromRoute] int id)
		//{
		//	if (id <= 0)
		//		ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

		//	await _createOrderService.DeleteOrderAsync(id);

		//	ResponseUtil respUtil = new ResponseUtil(true, "Pedido excluído com sucesso"); 
		//	return Ok(respUtil);
		//}
	}
}