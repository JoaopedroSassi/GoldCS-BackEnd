using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.ClientDTOS;
using src.Services.Interfaces;
using src.Utils;

namespace src.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ClientController : ControllerBase
	{
		private readonly IClientService _service;

		public ClientController(IClientService service)
		{
			_service = service;
		}

		[HttpGet("{cpf}")]
		public async Task<ActionResult<ClientDetailsDTO>> GetClientByCpf(string cpf)
		{
			if (!(StringExtensions.IsCpfValid(cpf)))
				ExceptionExtensions.ThrowBaseException("CPF no formato inválido", HttpStatusCode.NotFound);

			var client = await _service.GetClientByCpfAsync(cpf);
			ResponseUtil respUtil = new ResponseUtil(true, client); 
			return Ok(respUtil);
		}
	}
}