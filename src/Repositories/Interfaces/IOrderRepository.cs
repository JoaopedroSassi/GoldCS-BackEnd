using src.Models.Entities;

namespace src.Repositories.Interfaces
{
	public interface IOrderRepository : IBaseRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
    }
}