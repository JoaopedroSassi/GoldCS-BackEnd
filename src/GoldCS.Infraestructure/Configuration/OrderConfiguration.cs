using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Infraestructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp");
           
            builder.Property(x => x.DeliveryDate)
                .HasColumnType("timestamp");
            
            builder.Property(o => o.UserName)
                .IsRequired();
            
            builder.Property(o => o.Status)
                .IsRequired();
            builder.Property(x => x.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(12,2)");
            
            
            builder.HasMany(o => o.Products)
                .WithOne(op => op.Order)
                .HasForeignKey("OrderId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey("ClientId");
            
            builder.HasOne(o => o.Adress)
                .WithMany()
                .HasForeignKey("AdressId"); 

        }
    }
}
