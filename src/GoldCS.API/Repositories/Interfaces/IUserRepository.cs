using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface IUserRepository : IBaseRepository
    {
        Task<User> GetUserByEmail(string email);
		Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers(QueryPaginationParameters paginationParameters);
    }
}