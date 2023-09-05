using System.Net;
using GoldCSAPI.Models.DTO.UserDTOS;
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

		public async Task<LoginReturnDTO> Login(UserLoginDTO model)
		{
			var user = await _userRepository.GetUserByEmail(model.Email);

			if (user is null)
				ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			if (!(CryptoExtension.ComparePassword(model.Password, user.Password)))
				ExceptionExtensions.ThrowBaseException("Informações inválidas", HttpStatusCode.BadRequest);

			var token = _tokenService.GenerateToken(new UserGenerateTokenDTO(user));
			var refreshToken = _tokenService.GenerateRefreshToken();
			_tokenService.SaveRefreshToken(user.Email, refreshToken);

			return new LoginReturnDTO(token, refreshToken, user.UserID, user.Email, user.Name, user.Role);
		}

		public async Task<TokenWithRefreshTokenDTO> Refresh(TokenWithRefreshTokenDTO model, int userId)
		{
			var user = await _userRepository.GetUserById(userId);

			if (user is null)
				ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			var principal = _tokenService.GetPrincipalFromExpiredToken(model.Token);
			var savedRefreshToken = _tokenService.GetRefreshToken(user.Email);
			if (savedRefreshToken != model.RefreshToken)
				ExceptionExtensions.ThrowBaseException("Tokens conflitantes", HttpStatusCode.BadRequest);

			var newToken = _tokenService.GenerateToken(principal.Claims);
			var newRefreshToken = _tokenService.GenerateRefreshToken();
			_tokenService.DeleteRefreshToken(user.Email, savedRefreshToken);
			_tokenService.SaveRefreshToken(user.Email, newRefreshToken);

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

        public async Task EditUser(UserUpdateDTO model, int id)
        {
			var user = await _userRepository.GetUserById(id);

			if (user is null)
                ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			if (user.UserID != id)
                ExceptionExtensions.ThrowBaseException("IDs divergentes", HttpStatusCode.NotFound);

			if (!(model.Password.IsPasswordValid()))
				ExceptionExtensions.ThrowBaseException("Senha no formato inválido", HttpStatusCode.BadRequest);

			if (!(model.Email.IsEmailValid()))
				ExceptionExtensions.ThrowBaseException("Email no formato inválido", HttpStatusCode.BadRequest);

			user.Name = model.Name ?? user.Name;
            user.Email = model.Email ?? user.Email;
            user.Password = CryptoExtension.CodifyPassword(model.Password) ?? user.Password;

			_userRepository.Update(user);
            if (!(await _userRepository.SaveChangesAsync()))
                ExceptionExtensions.ThrowBaseException("Erro ao atualizar usuário no banco de dados", HttpStatusCode.BadRequest);
        }

        public async Task<UserDetailsDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

			if (user is null)
                ExceptionExtensions.ThrowBaseException("Usuário nulo", HttpStatusCode.NotFound);

			return new UserDetailsDTO(user);
        }
    }
}