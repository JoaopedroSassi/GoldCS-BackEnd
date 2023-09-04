using GoldCSAPI.Models.DTO.UserDTOS;
using src.Models.DTO.UserDTOS;

namespace src.Services.Interfaces
{
	public interface IUserService
	{
		Task RegisterUser(UserRegisterDTO model);
		Task DeleteUser(int id);
		Task<LoginReturnDTO> Login(UserLoginDTO model);
		Task<TokenWithRefreshTokenDTO> Refresh(TokenWithRefreshTokenDTO model, int userId);
		Task EditUser(UserUpdateDTO model, int id);
		Task<UserDetailsDTO> GetUserById(int id);
	}
}