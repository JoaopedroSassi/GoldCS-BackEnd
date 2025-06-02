using GoldCS.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Infraestructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.CellPhone)
                .HasMaxLength(15);
            builder.Property(c => c.Phone)
                .HasMaxLength(15);

            builder.Property(c => c.RegisterDate)
                .IsRequired()
                .HasColumnType("timestamp");
        }
    }
}
