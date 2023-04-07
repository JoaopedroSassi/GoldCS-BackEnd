using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface ICategoryRepository : IBaseRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
		Task<List<Category>> GetCategoriesAsync(CategoriesParameters categoriesParameters);
		Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}