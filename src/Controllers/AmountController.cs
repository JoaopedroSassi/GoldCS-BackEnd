using System.Net;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.Amount;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class AmountController : ControllerBase
    {
        private readonly IAmountService _amountService;

		public AmountController(IAmountService amountService)
		{
			_amountService = amountService;
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertAmountAsync([FromBody] AmountInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _amountService.InsertAmountAsync(model);
			return Ok("Estoque inserido");
		}
	}
}