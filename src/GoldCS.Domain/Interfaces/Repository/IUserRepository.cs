using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        void Detached(ApplicationUser user);
    }
}
