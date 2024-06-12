using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Pagination;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class OrderRepository : BaseRepository, IOrderRepository
	{
		private readonly GoldCSDBContext _context;

		public OrderRepository(GoldCSDBContext context) : base(context)
		{
			_context = context;
		}

		public Task<Order> GetOrderByIdAsync(int id)
		{
			return _context.Orders.AsNoTracking()
								.Include(x => x.Address)
								.Include(x => x.Client)
								.Include(x => x.User)
								.Include(x => x.OrderProducts)
								.ThenInclude(x => x.Product)
								.FirstOrDefaultAsync(x => x.OrderID == id);
		}
		public  Task<List<Order>> GetAllOrdersAsync(QueryPaginationParameters paginationParameters)
		{
			return _context.Orders.AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.Client)
                .Include(x => x.User)
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
				.Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
				.Take(paginationParameters.PageSize)
                .OrderBy(x => x.OrderDate)
				.ToListAsync();
        }

    }
}