using src.Models.Entities;

namespace src.Repositories.Interfaces
{
	public interface ICategoryRepository : IBaseRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
		Task<IEnumerable<Category>> GetCategoriesAsync();
		Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}