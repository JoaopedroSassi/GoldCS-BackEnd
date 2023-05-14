using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
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
								.Include(x => x.Products)
								.FirstOrDefaultAsync(x => x.OrderID == id);
		}
	}
}