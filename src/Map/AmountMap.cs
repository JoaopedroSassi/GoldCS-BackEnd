using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class AmountMap : IEntityTypeConfiguration<Amount>
	{
		public void Configure(EntityTypeBuilder<Amount> builder)
		{
			builder.ToTable("tb_amount");

			builder.HasKey(x => x.AmountID);
            builder.Property(x => x.AmountID).ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
			builder.Property(x => x.Price).HasColumnType("decimal").IsRequired();
			builder.Property(x => x.AmountDate).HasColumnType("datetime").IsRequired();

			builder.HasOne(x => x.Product).WithMany(x => x.Amounts).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.SetNull);
		}
	}
}