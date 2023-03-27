using System.Net;
using Microsoft.AspNetCore.Mvc;
using src.Entities.DTO.Client;
using src.Exceptions;
using src.Models.DTO.Client;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
		private readonly IClientService _service;

		public ClientController(IClientService service)
		{
			_service = service;
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ClientDetailsDTO>> GetClientByIdAsync(int id)
		{
			if (id <= 0)
				throw new BaseException("Id menor ou igual a 0", HttpStatusCode.BadRequest, typeof(System.Exception).FullName);
			
			var client = await _service.GetClientByIdAsync(id);
			if (client is null)
				throw new BaseException("Cliente não encontrado", HttpStatusCode.NotFound, typeof(NotFoundObjectResult).FullName);

			return Ok(client);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClientDetailsDTO>>> GetAllClientAsync()
		{
			var clients = await _service.GetAllClientsAsync();
			if (!clients.Any())
				throw new BaseException("Sem clientes cadastrados", HttpStatusCode.NotFound, typeof(NotFoundObjectResult).FullName);

			return Ok(clients);
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertClientAsync([FromBody] ClientInsertDTO model)
		{
			bool insert = await _service.InsertClientAsync(model);
			
			if (!insert)
				throw new BaseException("Erro ao inserir", HttpStatusCode.BadRequest, typeof(BadHttpRequestException).FullName);
			
			return Ok("Cliente inserido com sucesso");
		}
    }
}