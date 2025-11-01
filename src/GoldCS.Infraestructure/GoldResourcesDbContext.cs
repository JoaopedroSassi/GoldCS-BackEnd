using GoldCS.Domain.Models.Entities;
using GoldCS.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GoldCS.Infraestructure
{
    public class GoldResourcesDbContext : DbContext
    {
        public GoldResourcesDbContext(DbContextOptions<GoldResourcesDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Adress> Adresses { get; set; }

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
