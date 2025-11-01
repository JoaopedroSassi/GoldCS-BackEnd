using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace GoldCS.API.Controllers
{
	[ApiController]
	[Route("api/client")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ClientController : MainController
	{
		private readonly IClientService _clientService;

        public ClientController(IClientService service, INotificationService notificationService) : base(notificationService)
		{
			_clientService = service;
		}

		[HttpGet("cpf")]
		public async Task<IActionResult> GetClientByCpf([FromBody] ClientRequests.GetByCpf request)
		{
            var ret = await _clientService.GetClientByCpf(request);
            return CustomResponse(ret);
        }
		
		[HttpGet()]
		public async Task<IActionResult> GetAll()
		{
            var ret = await _clientService.GetClients();
            return CustomResponse(ret);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ret = await _clientService.GetClientById(id);
            return CustomResponse(ret);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient([FromBody] ClientRequests.RegisterClient request)
        {
            await _clientService.RegisterClient(request);
            return CustomResponse(); 
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] ClientRequests.UpdateClient request)
        {
            await _clientService.UpdateClient(request);
            return CustomResponse();
        }
    }
}