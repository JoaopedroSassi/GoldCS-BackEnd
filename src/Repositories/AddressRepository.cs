using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
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

		public async Task<Address> GetAddressByCep(string cep)
		{
			return await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.Cep == cep); 
		}
	}
}