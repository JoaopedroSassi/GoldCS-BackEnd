using Microsoft.EntityFrameworkCore;
using src.Entities.Models;

namespace src.Data
{
	public class GoldCSDBContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }

		public GoldCSDBContext(DbContextOptions<GoldCSDBContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		}
	}
}