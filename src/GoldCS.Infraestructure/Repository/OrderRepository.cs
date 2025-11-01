using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure.Repository
{
    public class OrderRepository : BaseCrudRepository<Order>, IOrderRepository
    {
        private readonly GoldResourcesDbContext _context; 
        public OrderRepository(GoldResourcesDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Order>> GetAll()
        {
            return _context.Orders.AsNoTracking()
                                    .Include(x => x.Adress)
                                    .Include(x => x.Client)
                                    .Include(x => x.Products)
                                    .ThenInclude(x => x.Product)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .ToListAsync();
        }

        public Task<Order> GetOrder(int id)
        {
            return _context.Orders.AsNoTracking()
                                .Include(x => x.Adress)
                                .Include(x => x.Client)
                                .Include(x => x.Products)
                                .ThenInclude(x => x.Product)
                                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
