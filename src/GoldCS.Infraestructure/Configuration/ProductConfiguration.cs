using GoldCS.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace GoldCS.Infraestructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public virtual void Configure(EntityTypeBuilder<ProductEntity> entity)
        {
            entity.ToTable("Products");

            entity.HasKey(x => x.Id);
            entity
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            entity
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
            entity
                .Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();
            entity
                .Property(x => x.Price)
                .HasColumnType("decimal(12,4)")
                .IsRequired();
            entity
                .Property(x => x.Stock)
                .HasColumnType("int")
                .IsRequired();
            entity
                .Property(x => x.Width)
                .HasColumnType("decimal(12,4)")
                .IsRequired();
            entity
                .Property(x => x.Height)
                .HasColumnType("decimal(12,4)")
                .IsRequired();
            entity
                .Property(x => x.Stock)
                .HasColumnType("int")
                .IsRequired();

            entity
                .HasOne(x => x.CategoryNavigation)
                .WithMany(y => y.ProductsEntity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
