using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure.Repository
{
    public class CategoryRepository : BaseCrudRepository<Category>, ICategoryRepository
    {
        private readonly GoldResourcesDbContext _context;

        public CategoryRepository(GoldResourcesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
