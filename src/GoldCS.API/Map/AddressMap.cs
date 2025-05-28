using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class AddressMap : IEntityTypeConfiguration<Address>
	{
		public virtual void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("tb_address");

			builder.HasKey(x => x.AddressID);
            builder.Property(x => x.AddressID).ValueGeneratedOnAdd();

			builder.Property(x => x.Cep).HasColumnType("varchar(10)").IsRequired();
			builder.HasIndex(x => x.Cep).IsUnique();

			builder.Property(x => x.AddressName).HasColumnType("varchar(200)").IsRequired();
			builder.Property(x => x.City).HasColumnType("varchar(100)").IsRequired();
			builder.Property(x => x.District).HasColumnType("varchar(100)").IsRequired();
			builder.Property(x => x.UF).HasColumnType("varchar(2)").IsRequired();
			builder.Property(x => x.Number).HasColumnType("varchar(25)").IsRequired();
			builder.Property(x => x.Complement).HasColumnType("varchar(200)").IsRequired(false);
        }
	}
}