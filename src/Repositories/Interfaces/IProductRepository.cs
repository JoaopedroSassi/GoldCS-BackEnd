using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface IProductRepository : IBaseRepository
    {
        Task<Product> GetProductByIdAsync(int id);
		Task<List<Product>> GetproductsAsync(QueryPaginationParameters paginationParameters);
    }
}