using src.Models.DTO.OrderDTOS;
using src.Pagination;

namespace src.Services.Interfaces
{
	public interface IOrderService
    {
        Task<PagedList<OrderDetailsDTO>> GetAllOrdersAsync(QueryPaginationParameters paginationParameters);
        Task<int> InsertOrderAsync(OrderInsertDTO model);
		Task<OrderDetailsDTO> GetOrderByIdAsync(int id);
		Task DeleteOrderAsync(int id);
    }
}