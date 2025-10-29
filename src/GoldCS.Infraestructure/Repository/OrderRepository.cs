using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Models.Entities;

namespace GoldCS.Infraestructure.Repository
{
    public class OrderRepository : BaseCrudRepository<Order>, IOrderRepository
    {
        private readonly GoldResourcesDbContext _context; 
        public OrderRepository(GoldResourcesDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
