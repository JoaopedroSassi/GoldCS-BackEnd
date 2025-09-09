using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class UserMap : IEntityTypeConfiguration<User>
    {
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("tb_users");

			builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).ValueGeneratedOnAdd();

			builder.Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
			builder.Property(x => x.Email).HasColumnType("varchar(200)").IsRequired();
			builder.Property(x => x.Password).HasColumnType("varchar(500)").IsRequired();
			builder.Property(x => x.Active).HasColumnType("boolean").IsRequired();
			builder.Property(x => x.Role).HasColumnType("varchar(200)").IsRequired();
		}
	}
}