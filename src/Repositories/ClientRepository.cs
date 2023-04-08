using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Entities.Models;
using src.Pagination;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class ClientRepository : BaseRepository, IClientRepository
	{
		private readonly GoldCSDBContext _context;

        public ClientRepository(GoldCSDBContext context) : base(context)
        {
            _context = context;
        }

		public async Task<Client> GetClientByIdAsync(int id)
		{
			return await _context.Clients.Where(x => x.ClientID == id).FirstOrDefaultAsync();
		}

		public async Task<List<Client>> GetClientsAsync(QueryPaginationParameters paginationParameters)
		{
			return await _context.Clients.AsNoTracking().Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize).Take(paginationParameters.PageSize).ToListAsync();
		}
	}
}