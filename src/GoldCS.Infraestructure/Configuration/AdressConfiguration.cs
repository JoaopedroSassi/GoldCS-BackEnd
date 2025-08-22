using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldCS.Domain.Util.Configurations
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.CEP)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(a => a.Logradouro)
                .HasMaxLength(200);

            builder.Property(a => a.Numero)
                .HasMaxLength(20);

            builder.Property(a => a.Bairro)
                .HasMaxLength(100);

            builder.Property(a => a.UF)
                .HasMaxLength(2);

            builder.Property(a => a.Complemento)
                .HasMaxLength(200);

            builder.HasOne<Client>()                
                   .WithMany()                    
                   .HasForeignKey(a => a.ClientId) 
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
