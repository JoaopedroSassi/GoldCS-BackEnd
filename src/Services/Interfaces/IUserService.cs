using src.Models.DTO.User;

namespace src.Services.Interfaces
{
	public interface IUserService
    {
        Task RegisterUser(UserRegisterDTO model);
		Task DeleteUser(int id);
		Task<string> Login(UserLoginDTO model);
    }
}