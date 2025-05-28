using GoldCS.Domain.Repository.Interfaces;
using GoldCS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GoldCS.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GoldIdentityDbContext _DbIdentity;
        private readonly UserManager<ApplicationUser> _UserManager;

        public UserRepository(
                        GoldIdentityDbContext context,
                        UserManager<ApplicationUser> userManager
            )
        {
            _DbIdentity = context;
            _UserManager = userManager;
        }
        public void Detached(ApplicationUser user)
        {
            _DbIdentity.Entry(user).State = EntityState.Detached;
        }
    }
}
