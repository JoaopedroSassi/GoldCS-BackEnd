using src.Models.DTO.UserDTOS;

namespace src.Services.Interfaces
{
	public interface IUserService
    {
        Task RegisterUser(UserRegisterDTO model);
		Task DeleteUser(int id);
		Task<string> Login(UserLoginDTO model);
    }
}