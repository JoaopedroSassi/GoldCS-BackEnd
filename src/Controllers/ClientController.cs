using System.Net;
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

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClientDetailsDTO>>> GetAllClientAsync()
		{
			return Ok(await _service.GetAllClientsAsync());
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ClientDetailsDTO>> GetClientByIdAsync(int id)
		{
			if (id <= 0)
			{
				var ex = new Exception("ID menor ou igual a 0");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}
			
			return Ok(await _service.GetClientByIdAsync(id));
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertClientAsync([FromBody] ClientInsertDTO model)
		{
			if (!(ModelState.IsValid))
			{
				var ex = new Exception("Formato inválido");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}

			await _service.InsertClientAsync(model);
			return Ok("Cliente inserido");
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteClientAsync(int id) 
		{
			if (id <= 0)
			{
				var ex = new Exception("ID menor ou igual a 0");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}
			
			await _service.DeleteClientAsync(id);
			return Ok("Cliente deletado com sucesso");
		}
    }
}