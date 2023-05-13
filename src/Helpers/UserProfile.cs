using AutoMapper;
using src.Models.DTO.User;
using src.Models.Entities;

namespace src.Helpers
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserRegisterDTO>();
			CreateMap<UserRegisterDTO, User>();
		}
	}
}