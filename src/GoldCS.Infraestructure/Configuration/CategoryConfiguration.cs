
using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldCS.Infraestructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Categories");

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
