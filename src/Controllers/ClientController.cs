using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entities.DTO.ClientDTOS;
using src.Extensions;
using src.Models.DTO.ClientDTOS;
using src.Pagination;
using src.Services.Interfaces;

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

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClientDetailsDTO>>> GetAllClientAsync([FromQuery] QueryPaginationParameters paginationParameters)
		{
			var clients = await _service.GetAllClientsAsync(paginationParameters);

			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new PaginationReturn(clients.TotalCount, clients.PageSize, clients.CurrentPage, clients.TotalPages, clients.hasNext, clients.hasPrevious)));

			return Ok(clients);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ClientDetailsDTO>> GetClientByIdAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("Id menor ou igual a 0", HttpStatusCode.NotFound);
			
			return Ok(await _service.GetClientByIdAsync(id));
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertClientAsync([FromBody] ClientInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.InsertClientAsync(model);
			return Ok("Cliente inserido");
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteClientAsync(int id) 
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("Id menor ou igual a 0", HttpStatusCode.NotFound);

			await _service.DeleteClientAsync(id);
			return Ok("Cliente deletado com sucesso");
		}
    }
}