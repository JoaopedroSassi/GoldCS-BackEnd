using src.Models.Entities;

namespace src.Repositories.Interfaces
{
	public interface IUserRepository : IBaseRepository
    {
        Task<User> GetUserByEmail(string email);
		Task<User> GetUserById(int id);
    }
}