using src.Models.DTO.Category;
using src.Models.DTO.Product;

namespace src.Services.Interfaces
{
	public interface ICategoryService
    {
        Task InsertCategoryAsync(CategoryInsertDTO model);
		Task DeleteCategoryAsync(int id);
		Task UpdateCategoryAsync(CategoryUpdateDTO model);
		Task<IEnumerable<CategoryDetailsDTO>> GetAllCategoriesAsync();
		Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id);
		Task<IEnumerable<ProductDetailsDTO>> GetProductsByCategoryAsync(int categoryId);
    }
}