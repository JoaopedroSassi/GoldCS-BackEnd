using GoldCS.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoldCS.Domain.Models.Entities;


namespace GoldCS.Infraestructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public virtual void Configure(EntityTypeBuilder<Product> entity)
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
                .Property(x => x.CostPrice)
                .HasColumnType("decimal(12,2)")
                .IsRequired();
            entity
                .Property(x => x.Stock)
                .HasColumnType("int")
                .IsRequired();
            entity
                .Property(x => x.Width)
                .HasColumnType("decimal(12,2)")
                .IsRequired();
            entity
                .Property(x => x.Height)
                .HasColumnType("decimal(12,2)")
                .IsRequired();
            entity
                .Property(x => x.Stock)
                .HasColumnType("int")
                .IsRequired();

            entity
                .HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
