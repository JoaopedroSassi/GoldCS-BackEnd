
using GoldCSDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure
{
    public class GoldCSContext : DbContext
    {
        public GoldCSContext(DbContextOptions<GoldCSContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoldCSContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
