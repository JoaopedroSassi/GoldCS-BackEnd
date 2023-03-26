using Microsoft.AspNetCore.Mvc;
using src.Entities.DTO.Client;
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
				return BadRequest("Id inválido");

			var client = await _service.GetClientByIdAsync(id);
			if (client is null)
				return BadRequest("Cliente não existe");

			return Ok(client);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClientDetailsDTO>>> GetAllClientAsync()
		{
			var clients = await _service.GetAllClientsAsync();
			if (!clients.Any())
				return BadRequest("Sem clientes cadastrados");

			return Ok(clients);
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertClientAsync([FromBody] ClientInsertDTO model)
		{
			bool insert = await _service.InsertClientAsync(model);
			
			if (!insert)
				return BadRequest("Erro ao inserir");
			
			return Ok("Cliente inserido com sucesso");
		}
    }
}