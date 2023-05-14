using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.AmountDTOS;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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