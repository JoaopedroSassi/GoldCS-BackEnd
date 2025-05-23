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

			builder.Property(x => x.OrderDate).HasColumnType("timestamp").IsRequired();
			builder.Property(x => x.PaymentMethod).HasColumnType("varchar(200)").IsRequired();
			builder.Property(x => x.Total).HasColumnType("money").IsRequired();
			builder.Property(x => x.DeliveryForecast).HasColumnType("timestamp").IsRequired();

			builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserID);
			builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressID);
			builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.ClientID);
		}
	}
}