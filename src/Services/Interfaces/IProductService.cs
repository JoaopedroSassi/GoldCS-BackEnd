using src.Models.DTO.Product;
using src.Pagination;

namespace src.Services.Interfaces
{
	public interface IProductService
    {
        Task InsertProductAsync(ProductInsertDTO model);
		Task DeleteProductAsync(int id);
		Task UpdateProductAsync(ProductUpdateDTO model);
		Task<PagedList<ProductDetailsDTO>> GetAllProductsAsync(QueryPaginationParameters paginationParameters);
		Task<ProductDetailsDTO> GetProductByIdAsync(int id);
    }
}