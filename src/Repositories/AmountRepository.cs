using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Pagination;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class AmountRepository : BaseRepository, IAmountRepository
	{
        private readonly GoldCSDBContext _context;

        public AmountRepository(GoldCSDBContext context) : base(context)
        {
            _context = context;
        }

		public async Task<Amount> GetAmountByIdAsync(int id)
		{
			return await _context.Amounts.AsNoTracking().Include(x => x.Product).FirstOrDefaultAsync(x => x.ProductID == id); 
		}

		public async Task<List<Amount>> GetAmountsAsync(QueryPaginationParameters paginationParameters)
		{
			return await _context.Amounts.AsNoTracking().Include(x => x.Product).Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize).Take(paginationParameters.PageSize).ToListAsync();
		}
	}
}