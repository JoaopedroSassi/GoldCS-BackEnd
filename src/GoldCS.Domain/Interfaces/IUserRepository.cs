using GoldCS.Domain.Models;

namespace GoldCS.Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindUserByEmail(string email);
        Task<User> FindUserById(int id);
        Task<List<User>> ListUsers();
    }
}
