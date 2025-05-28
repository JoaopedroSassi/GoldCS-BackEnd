using Microsoft.AspNetCore.Mvc;
using src.Models.DTO.MailDTOS;
using src.Services.Interfaces;
using src.Extensions;
using System.Net;
using src.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace src.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class MailController : ControllerBase
	{
		private readonly IMailService _mailService;
		private readonly IOrderService _orderService;

		public MailController(IMailService mailService, IOrderService orderService)
		{
			_mailService = mailService;
			_orderService = orderService;
		}

		[HttpPost("{orderID:int}")]
		public async Task<IActionResult> SendEmail(int orderID)
		{
			if (orderID <= 0)
				ExceptionExtensions.ThrowBaseException("ID do pedido inválido", HttpStatusCode.NotFound);

			var order = await _orderService.GetOrderByIdAsync(orderID);
			/*if (order.OrderID != model.OrderID)
				ExceptionExtensions.ThrowBaseException("Pedido com ID conflitante", HttpStatusCode.BadRequest);
			
			if (order.Client.Email != model.Email)
				ExceptionExtensions.ThrowBaseException("Email do cliente diferente da requisição", HttpStatusCode.BadRequest);*/

			_mailService.SendEmail(order);
			ResponseUtil respUtil = new ResponseUtil(true, "Email enviado com sucesso!"); 
			return Ok(respUtil);
		}
	}
}