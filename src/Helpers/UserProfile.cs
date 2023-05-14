using AutoMapper;
using src.Models.DTO.UserDTOS;
using src.Models.Entities;

namespace src.Helpers
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserRegisterDTO, User>();

			CreateMap<User, UserGenerateTokenDTO>();
		}
	}
}