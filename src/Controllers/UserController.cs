using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Models.DTO.User;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
		private readonly ITokenService _tokenService;
		private readonly IUserService _userService;

		public UserController(ITokenService tokenService, IUserService userService)
		{
			_tokenService = tokenService;
			_userService = userService;
		}

		/*[HttpPost("LoginUser")]
		public async Task<ActionResult<string>> Login([FromBody] UserLoginDTO model)
		{
			// Buscar o usuario do banco -> Lembrar de usar o encripter
			
			
			var result = await _authenticate.Authenticate(model.Email, model.Password);

			if (!result)
				ExceptionExtensions.ThrowBaseException("Login inválido", HttpStatusCode.BadRequest);

			return GenerateToken(model);
		}*/
    }
}