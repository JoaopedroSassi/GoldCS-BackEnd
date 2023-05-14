using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models.Entities;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly GoldCSDBContext _context;

        public UserRepository(GoldCSDBContext context) : base(context)
        {
            _context = context;
        }

		public async Task<User> GetUserByEmail(string email)
		{
			return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
		}

		public async Task<User> GetUserById(int id)
		{
			return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserID == id);
		}
	}
}