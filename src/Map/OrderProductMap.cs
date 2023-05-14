using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
	{
		public void Configure(EntityTypeBuilder<OrderProduct> builder)
		{
			builder.ToTable("tb_order_product");

			builder.HasKey(x => new { x.ProductID, x.OrderID });

			builder.Property(x => x.Quantity).IsRequired();
			builder.Property(x => x.FinalPrice).HasPrecision(5, 2).IsRequired();

			builder.HasOne(x => x.Order).WithMany(x => x.OrderProducts).HasForeignKey(x => x.OrderID);
			builder.HasOne(x => x.Product).WithMany(x => x.OrderProducts).HasForeignKey(x => x.ProductID);

			builder.Property(x => x.ProductID).IsRequired();
			builder.Property(x => x.OrderID).IsRequired();
		}
	}
}