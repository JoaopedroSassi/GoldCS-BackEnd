using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class CategoryRepository : BaseRepository, ICategoryRepository
	{
		private readonly GoldCSDBContext _context;

        public CategoryRepository(GoldCSDBContext context) : base(context)
        {
            _context = context;
        }
		
		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			return await _context.Categories.AsNoTracking().ToListAsync(); 
		}

		public async Task<Category> GetCategoryByIdAsync(int id)
		{
			return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryID == id); 
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
		{
			return (IEnumerable<Product>) await _context.Categories.Select(x => x.Products).ToListAsync();
		}
	}
}