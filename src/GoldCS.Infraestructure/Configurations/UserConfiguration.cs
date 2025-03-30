using GoldCSDomain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Infraestructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "WebService");

            builder.HasKey(u => u.UserId);

            builder
                .Property(u => u.UserId)
                .UseIdentityColumn();
            
            builder.Property(x => x.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(MAX)").IsRequired();
            builder.Property(x => x.Active).HasColumnType("boolean").IsRequired();
            builder.Property(x => x.Role).HasColumnType("int").IsRequired();

        }
    }
}
