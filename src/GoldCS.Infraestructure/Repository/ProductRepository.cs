using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure.Repository
{
    public class ProductRepository : BaseCrudRepository<Product>, IProductRepository
    {
        private readonly GoldResourcesDbContext _context;

        public ProductRepository(GoldResourcesDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Product>> GetFromCategory(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}
