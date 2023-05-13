using src.Data;
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
    }
}