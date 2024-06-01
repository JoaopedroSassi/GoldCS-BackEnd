using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface IOrderRepository : IBaseRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<List<Order>> GetAllOrdersAsync(QueryPaginationParameters paginationParameters); 
    }
}