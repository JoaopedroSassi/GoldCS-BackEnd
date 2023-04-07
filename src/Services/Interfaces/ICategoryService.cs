using src.Models.DTO.Category;
using src.Models.DTO.Product;
using src.Pagination;

namespace src.Services.Interfaces
{
	public interface ICategoryService
    {
        Task InsertCategoryAsync(CategoryInsertDTO model);
		Task DeleteCategoryAsync(int id);
		Task UpdateCategoryAsync(CategoryUpdateDTO model);
		Task<PagedList<CategoryDetailsDTO>> GetAllCategoriesAsync(CategoriesParameters categoriesParameters);
		Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id);
		Task<IEnumerable<ProductDetailsDTO>> GetProductsByCategoryAsync(int categoryId);
    }
}