using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface IAmountRepository : IBaseRepository
    {
        Task<Amount> GetAmountByIdAsync(int id);
		Task<List<Amount>> GetAmountsAsync(QueryPaginationParameters paginationParameters);
    }
}