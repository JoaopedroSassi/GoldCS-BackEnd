//using GoldCS.Domain.Repository.Interfaces;
//using GoldCS.Domain.Models;
//using Microsoft.EntityFrameworkCore;

//namespace GoldCS.Infraestructure.Repository
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly GoldCS _context;

//        public UserRepository(GoldCSContext context)
//        {
//            _context = context;
//        }
//        public async Task<User> FindUserByEmail(string email)
//        {          
//            return await _context.Users.Where(user => user.Email.Equals(email)).FirstOrDefaultAsync();
//        }
//        public async Task<List<User>> ListUsers()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        public async Task<User> FindUserById(int id)
//        {
//            return await _context.Users.Where(user => user.UserId.Equals(id)).FirstOrDefaultAsync();
//        }

//    }
//}
