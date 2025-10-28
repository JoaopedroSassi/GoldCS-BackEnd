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
	public class ClientController : ControllerBase
	{
		private readonly IClientService _clientService;
        private readonly INotificationService _notificationService;

        public ClientController(IClientService service, INotificationService notificationService)
		{
			_clientService = service;
			_notificationService = notificationService;
		}

		[HttpGet("cpf")]
		public async Task<IActionResult> GetClientByCpf([FromBody] ClientRequests.GetByCpf request)
		{
            var ret = await _clientService.GetClientByCpf(request);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<Client>().CriarSucesso(ret));
        }
		
		[HttpGet()]
		public async Task<IActionResult> GetAll()
		{
            var ret = await _clientService.GetClients();

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<List<Client>>().CriarSucesso(ret));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ret = await _clientService.GetClientById(id);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<Client>().CriarSucesso(ret));
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterClient([FromBody] ClientRequests.RegisterClient request)
        {
            await _clientService.RegisterClient(request);
            
            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode((int) HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] ClientRequests.UpdateClient request)
        {
            await _clientService.UpdateClient(request);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}