using GoldCS.Domain.Models;

namespace GoldCS.Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        void Detached(ApplicationUser user);
    }
}
