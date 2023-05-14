using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.User;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticateController : ControllerBase
	{
		private readonly IUserService _userService;

		public AuthenticateController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("LoginUser")]
		public async Task<ActionResult<string>> Login([FromBody] UserLoginDTO model)
		{
			if (!ModelState.IsValid)
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			var token = await _userService.Login(model);
			return Ok(new { token });
		}

		[Authorize]
		[HttpPost("RegisterUser")]
		public async Task<ActionResult<string>> Register([FromBody] UserRegisterDTO model)
		{
			if (!ModelState.IsValid)
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			if (model.Role.ToLower() == "admin" && !(User.IsInRole("admin")))
				ExceptionExtensions.ThrowBaseException("Somente admins podem registrar outros admins", HttpStatusCode.BadRequest);

			await _userService.RegisterUser(model);
			return Ok("Usuário inserido com sucesso");
		}

		[Authorize(Roles = "admin")]
		[HttpDelete("Delete/{id:int}")]
		public async Task<ActionResult<string>> DeleteUser(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			await _userService.DeleteUser(id);
			return Ok("Usuário deletado");
		}
	}
}