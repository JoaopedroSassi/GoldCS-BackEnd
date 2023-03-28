using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Entities.Models;

namespace src.Map
{
	public class ClientMap : IEntityTypeConfiguration<Client>
	{
		public virtual void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("tb_clients");

			builder.HasKey(x => x.ClientID);
            builder.Property(x => x.ClientID).ValueGeneratedOnAdd();

			builder.Property(x => x.Cpf).HasColumnType("varchar(15)").IsRequired();
            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
			builder.Property(x => x.Email).HasColumnType("varchar(150)").IsRequired();
			builder.Property(x => x.CellPhone).HasColumnType("varchar(15)").IsRequired();
			builder.Property(x => x.LandlinePhone).HasColumnType("varchar(15)").IsRequired(false);
        }
	}
}