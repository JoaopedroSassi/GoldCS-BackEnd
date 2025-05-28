using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Pagination;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly GoldCSDBContext _context;

        public ProductRepository(GoldCSDBContext context) : base(context)
        {
            _context = context;
        }

		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductID == id); 
		}
		
		public Product GetProductById(int id)
		{
			return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductID == id); 
		}

		public async Task<List<Product>> GetproductsAsync(QueryPaginationParameters paginationParameters)
		{
			return await _context.Products.AsNoTracking().Include(x => x.Category).OrderBy(x => x.ProductID).Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize).Take(paginationParameters.PageSize).ToListAsync();
		}

		public void UpdateRange(List<Product> models)
		{
			_context.Products.UpdateRange(models);		
		}
	}
}
