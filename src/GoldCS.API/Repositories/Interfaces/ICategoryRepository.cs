using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface ICategoryRepository : IBaseRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
		Task<List<Category>> GetCategoriesAsync(QueryPaginationParameters paginationParameters);
		Task<List<Product>> GetProductsByCategoryAsync(int categoryId);
		Task<int> GetCountProductsByCategoryAsync(int categoryId);
    }
}