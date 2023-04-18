using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Pagination;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class AddressRepository : BaseRepository, IAddressRepository
	{
		private readonly GoldCSDBContext _context;

        public AddressRepository(GoldCSDBContext context) : base(context)
        {
            _context = context;
        }

		public async Task<Address> GetAddressByIdAsync(int id)
		{
			return await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.AddressID == id);
		}

		public async Task<List<Address>> GetAddressesAsync(QueryPaginationParameters paginationParameters)
		{
			return await _context.Addresses.AsNoTracking().ToListAsync();
		}
	}
}