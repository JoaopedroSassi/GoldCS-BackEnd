using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

		[HttpPost]
		public async Task<ActionResult<string>> InsertOrderAsync([FromBody] OrderInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _orderService.InsertOrderAsync(model);
			return Ok("Pedido inserido");
		}
	}
}