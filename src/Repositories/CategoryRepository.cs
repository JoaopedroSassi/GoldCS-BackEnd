using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Pagination;
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
		
		public async Task<List<Category>> GetCategoriesAsync(QueryPaginationParameters paginationParameters)
		{
			return await _context.Categories.AsNoTracking().Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize).Take(paginationParameters.PageSize).ToListAsync();	
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