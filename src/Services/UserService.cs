using System.Net;
using AutoMapper;
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
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_tokenService = tokenService;
		}

		public async Task<string> Login(UserLoginDTO model)
		{
			var user = await _userRepository.GetUserByEmail(model.Email);

			if (user is null)
				ExceptionExtensions.ThrowBaseException("Usuário não encontrado", HttpStatusCode.NotFound);

			if (!(CryptoExtension.ComparePassword(model.Password, user.Password)))
				ExceptionExtensions.ThrowBaseException("Informações inválidas", HttpStatusCode.BadRequest);

			return _tokenService.GenerateToken(_mapper.Map<UserGenerateTokenDTO>(user));
		}

		public async Task RegisterUser(UserRegisterDTO model)
		{
			var user = await _userRepository.GetUserByEmail(model.Email);

			if (user is not null)
				ExceptionExtensions.ThrowBaseException("Email já utlizado", HttpStatusCode.NotFound);

			model.Password = CryptoExtension.CodifyPassword(model.Password);
			model.Role = model.Role.ToLower();

			_userRepository.Insert(_mapper.Map<User>(model));
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