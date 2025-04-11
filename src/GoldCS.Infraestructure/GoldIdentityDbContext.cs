using GoldCS.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure
{
    public class GoldIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GoldIdentityDbContext(DbContextOptions<GoldIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
