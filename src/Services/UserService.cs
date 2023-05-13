using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Models.DTO.User;
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

		public Task RegisterUser(UserRegisterDTO model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteUser(int id)
		{
			throw new NotImplementedException();
		}
	}
}