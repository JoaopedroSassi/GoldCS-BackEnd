using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class OrderMap : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("tb_order");

			builder.HasKey(x => x.OrderID);
			builder.Property(x => x.OrderID).ValueGeneratedOnAdd();

			builder.Property(x => x.OrderDate).HasColumnType("date").IsRequired();
			builder.Property(x => x.PaymetMethod).HasColumnType("varchar(200)").IsRequired();
			builder.Property(x => x.Total).HasPrecision(5, 2).IsRequired();
			builder.Property(x => x.DeliveryForecast).HasColumnType("date").IsRequired();

			builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserID);
			builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressID);
			builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.ClientID);

			builder.HasMany(x => x.Products)
					.WithMany(x => x.Orders)
					.UsingEntity<OrderProduct>(
						x => x.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductID),
						x => x.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderID),

						x =>
						{
							x.ToTable("tb_order_product");

							x.HasKey(x => new { x.ProductID, x.OrderID });

							x.Property(x => x.Quantity).IsRequired();
							x.Property(x => x.FinalPrice).HasPrecision(5, 2).IsRequired();

							x.Property(x => x.ProductID).IsRequired();
							x.Property(x => x.OrderID).IsRequired();
						}
					);
		}
	}
}