using System.Net;
using GoldCSAPI.Models.DTO.UserDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.UserDTOS;
using src.Services.Interfaces;
using src.Utils;

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

			ResponseUtil respUtil = new ResponseUtil(true, token);
			return Ok(respUtil);
		}

		[Authorize]
		[HttpPost("Refresh/{userId:int}")]
		public async Task<ActionResult<string>> Refresh([FromBody] TokenWithRefreshTokenDTO model, int userId)
		{
			if (!ModelState.IsValid)
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			var token = await _userService.Refresh(model, userId);

			ResponseUtil respUtil = new ResponseUtil(true, token);
			return Ok(respUtil);
		}

		[Authorize]
		[HttpPost("RegisterUser")]
		public async Task<ActionResult<string>> Register([FromBody] UserRegisterDTO model)
		{
			if (!ModelState.IsValid)
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			if (!(User.IsInRole("admin")))
				ExceptionExtensions.ThrowBaseException("Somente admins podem registrar outros admins", HttpStatusCode.BadRequest);

			await _userService.RegisterUser(model);
			ResponseUtil respUtil = new ResponseUtil(true, "Usuário inserido com sucesso");
			return Ok(respUtil);
		}

		[Authorize(Roles = "admin")]
		[HttpDelete("Delete/{id:int}")]
		public async Task<ActionResult<string>> DeleteUser(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			await _userService.DeleteUser(id);
			ResponseUtil respUtil = new ResponseUtil(true, "Usuário deletado");
			return Ok(respUtil);
		}

		[Authorize(Roles = "seller, admin")]
		[HttpGet("{id:int}")]
		public async Task<ActionResult<ResponseUtil>> GetUserById(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			var user = await _userService.GetUserById(id);
            ResponseUtil respUtil = new ResponseUtil(true, user);
            return Ok(respUtil);
        }

		[Authorize(Roles = "seller, admin")]
		[HttpPut("Update/{id:int}")]
		public async Task<ActionResult<ResponseUtil>> UpdadateUser(UserUpdateDTO model, int id)
		{
            if (!(ModelState.IsValid))
                ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _userService.EditUser(model, id);
            ResponseUtil respUtil = new ResponseUtil(true, "Usuário atualizado");
            return Ok(respUtil);
        }
	}
}