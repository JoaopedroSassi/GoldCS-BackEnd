using System.Net;
using src.Extensions;
using src.Models.DTO.UserDTOS;
using src.Models.Entities;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ITokenService _tokenService;

		public UserService(IUserRepository userRepository, ITokenService tokenService)
		{
			_userRepository = userRepository;
			_tokenService = tokenService;
		}

		public async Task<TokenWithRefreshTokenDTO> Login(UserLoginDTO model)
		{
			var user = await _userRepository.GetUserByEmail(model.Email);

			if (user is null)
				ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			if (!(CryptoExtension.ComparePassword(model.Password, user.Password)))
				ExceptionExtensions.ThrowBaseException("Informações inválidas", HttpStatusCode.BadRequest);

			var token = _tokenService.GenerateToken(new UserGenerateTokenDTO(user));
			var refreshToken = _tokenService.GenerateRefrehsToken();
			_tokenService.SaveRefreshToken(user.Email, refreshToken);

			return new TokenWithRefreshTokenDTO(token, refreshToken);
		}

		public async Task<TokenWithRefreshTokenDTO> Refresh(TokenWithRefreshTokenDTO model, int userId)
		{
			var user = await _userRepository.GetUserById(userId);

			if (user is null)
				ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			var principal = _tokenService.GetPrincipalFromExpiredToken(model.Token);
			var email = user.Email;
			var savedRefreshToken = _tokenService.GetRefreshToken(email);
			if (savedRefreshToken != model.RefreshToken)
				ExceptionExtensions.ThrowBaseException("Tokens conflitantes", HttpStatusCode.BadRequest);

			var newToken = _tokenService.GenerateToken(principal.Claims);
			var newRefreshToken = _tokenService.GenerateRefrehsToken();
			_tokenService.DeleteRefreshToken(email, savedRefreshToken);
			_tokenService.SaveRefreshToken(email, newRefreshToken);

			return new TokenWithRefreshTokenDTO(newToken, newRefreshToken);
		}

		public async Task RegisterUser(UserRegisterDTO model)
		{
			var user = await _userRepository.GetUserByEmail(model.Email);

			if (user is not null)
				ExceptionExtensions.ThrowBaseException("Email já utlizado", HttpStatusCode.NotFound);

			model.Password = CryptoExtension.CodifyPassword(model.Password);
			model.Role = model.Role.ToLower();

			_userRepository.Insert(new User(model));
			if (!(await _userRepository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar o usuário no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task DeleteUser(int id)
		{
			var user = await _userRepository.GetUserById(id);

			if (user is null)
				ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			_userRepository.Delete(user);
			if (!(await _userRepository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao deletar usuário no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}