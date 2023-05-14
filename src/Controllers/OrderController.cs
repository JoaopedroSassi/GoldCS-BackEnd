using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.OrderDTOS;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<OrderDetailsDTO>> GetOrderByIdAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			return Ok(await _orderService.GetOrderByIdAsync(id));
		}

		[HttpPost]
		public ActionResult<string> InsertOrder([FromBody] OrderInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			var orderId = _orderService.InsertOrderAsync(model);
			return Ok(new { orderId = orderId, res = "Pedido inserido" });
		}
	}
}