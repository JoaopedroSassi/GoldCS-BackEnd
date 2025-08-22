using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        void Detached(ApplicationUser user);
    }
}
