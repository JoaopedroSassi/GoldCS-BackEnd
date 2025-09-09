using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models.Entities;

namespace src.Map
{
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public virtual void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("tb_categories");

			builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryID).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
        }
	}
}