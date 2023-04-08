using src.Entities.Models;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface IClientRepository : IBaseRepository
    {
        Task<Client> GetClientByIdAsync(int id);
		Task<List<Client>> GetClientsAsync(QueryPaginationParameters paginationParameters);
    }
}