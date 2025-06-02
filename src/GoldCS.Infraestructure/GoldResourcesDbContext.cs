using GoldCS.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GoldCS.Infraestructure
{
    public class GoldResourcesDbContext : DbContext
    {
        public GoldResourcesDbContext(DbContextOptions<GoldResourcesDbContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GoldResourcesDbContext).Assembly);
            SetVarcharToVarcharUndefinedStringProperties(builder);   
            base.OnModelCreating(builder);
        }

        private void SetVarcharToVarcharUndefinedStringProperties(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }
        }
    }
}
