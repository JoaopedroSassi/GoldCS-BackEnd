using Microsoft.EntityFrameworkCore;
using src.Entities.Models;
using src.Models.Entities;

namespace src.Data
{
	public class GoldCSDBContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }

		public GoldCSDBContext(DbContextOptions<GoldCSDBContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

			modelBuilder.Entity<Category>().HasData(
				new Category(1, "Colchão"),
				new Category(2, "Cama"),
				new Category(3, "Travesseiro"),
				new Category(4, "Outros"),
				new Category(5, "Base / Baú"),
				new Category(6, "Cabeceira")
			);

			modelBuilder.Entity<Product>().HasData(
				new Product(1, "Baú casal Blidado", "1.38 x 1.88", 10, 890, 5),
				new Product(2, "Cabeceira Queen", "1.58", 100, 390, 6),
				new Product(3, "Colchão ProRelax Opala", "1.38 x 1.88 x 24cm", 10, 1500, 1),
				new Product(4, "Travesseiro Nasa DualFlex", "16cm", 20, 150, 3),

				new Product(5, "Travesseiro Cervical", "-", 50, 160, 3),

				new Product(6, "Colchão SanKonfort Le Griff", "1.38 x 188 x 33cm", 200, 2400, 1),
				new Product(7, "Colchão SanKonfort Le Griff", "1.58 x 198 x 33cm", 30, 2990, 1),
				new Product(8, "Colchão SanKonfort Le Griff", "1.93 x 203 x 33cm ", 90, 3200, 1),
				new Product(9, "Cama Bedrom Andressa Avelã", "1.38 x 188", 60, 2300, 2),
				new Product(10, "Colchão ProRelax Pro Hotel", "1.38 x 188 x 28cm", 70, 1500, 1)
			);

			modelBuilder.Entity<User>().HasData(
				new User(3, "Franchesco legal", "franchesco@gmail.com", "$2a$12$vHinXxf4yXtBDfGY6rVpae0VrQ2UladDGL4VydcbrwUd.sj4yY3sy", true, "admin"),
				new User(4, "Jones legal", "jones@gmail.com", "$2a$12$vHinXxf4yXtBDfGY6rVpae0VrQ2UladDGL4VydcbrwUd.sj4yY3sy", true, "seller")
			);
		}
	}
}