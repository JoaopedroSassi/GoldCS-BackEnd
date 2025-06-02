
using GoldCS.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldCS.Infraestructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> entity)
        {
            entity.ToTable("Category");

            entity
                .HasKey(c => c.Id);
            entity
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            entity
                .Property(c => c.Name)
                .HasMaxLength(255);
            entity
                .Property(c => c.Description)
                .HasMaxLength(255);
        }


    }
}
