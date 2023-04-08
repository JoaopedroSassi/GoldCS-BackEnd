using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public virtual void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tb_products");

			builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductID).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
			builder.Property(x => x.Version).HasColumnType("varchar(150)").IsRequired();

			builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);
        }
	}
}