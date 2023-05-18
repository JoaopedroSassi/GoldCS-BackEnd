using src.Models.DTO.ProductDTOS;
using src.Pagination;

namespace src.Services.Interfaces
{
	public interface IProductService
    {
        Task InsertProductAsync(ProductInsertDTO model);
        Task InsertAmountProductAsync(ProductAmountInsertDTO model);
		Task RemoveAmountProductsAsync(List<ProductAmountRemoveDTO> model);
		Task DeleteProductAsync(int id);
		Task UpdateProductAsync(ProductUpdateDTO model);
		Task<PagedList<ProductDetailsDTO>> GetAllProductsAsync(QueryPaginationParameters paginationParameters);
		Task<ProductDetailsDTO> GetProductByIdAsync(int id);
    }
}