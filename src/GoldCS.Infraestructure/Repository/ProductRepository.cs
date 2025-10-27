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

        public async Task<List<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetFromCategory(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task InsertAmount(int amountToAdd, Product product)
        {
            product.Stock += amountToAdd; 
            await Update(product);
        }

        public async Task Inactivate(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.Active = false;
            await Update(product);
        }

    }
}
