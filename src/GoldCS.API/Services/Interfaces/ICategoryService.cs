using src.Models.DTO.CategoryDTOS;
using src.Models.DTO.ProductDTOS;
using src.Pagination;

namespace src.Services.Interfaces
{
	public interface ICategoryService
    {
        Task InsertCategoryAsync(CategoryInsertDTO model);
		Task DeleteCategoryAsync(int id);
		Task UpdateCategoryAsync(CategoryUpdateDTO model, int id);
		Task<PagedList<CategoryDetailsDTO>> GetAllCategoriesAsync(QueryPaginationParameters paginationParameters);
		Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id);
		Task<IEnumerable<ProductByCategoryDTO>> GetProductsByCategoryAsync(int categoryId);
    }
}