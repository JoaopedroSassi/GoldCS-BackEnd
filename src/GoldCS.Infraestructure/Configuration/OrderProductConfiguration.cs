using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> b)
    {
        b.ToTable("OrderProducts");

        b.HasKey(op => op.Id);


        b.Property(op => op.UnitaryValue)
            .HasColumnType("decimal(12,2)")
            .IsRequired();
        
        b.Property(x => x.Quantity)
            .IsRequired();

        b.Property(x => x.TotalValue)
            .HasColumnType("decimal(12,2)");
        
        b.HasOne(op => op.Order)
            .WithMany(o => o.Products)
            .HasForeignKey("OrderId")
            .OnDelete(DeleteBehavior.Restrict);
        
        b.HasOne(op => op.Product)
            .WithMany() 
            .HasForeignKey("ProductId")
            .OnDelete(DeleteBehavior.Restrict);

    }
}
