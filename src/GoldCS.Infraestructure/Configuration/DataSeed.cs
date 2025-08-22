using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldCS.Infra.Data.Seeds
{
    public class DataSeed :
        IEntityTypeConfiguration<Client>,
        IEntityTypeConfiguration<Category>,
        IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client
                {
                    Id = 1,
                    Name = "João Silva",
                    Cpf = "12345678901",
                    Email = "joao.silva@example.com",
                    CellPhone = "11912345678",
                    Phone = "1132345678",
                    RegisterDate = DateTime.UtcNow
                },
                new Client
                {
                    Id = 2,
                    Name = "Maria Oliveira",
                    Cpf = "98765432100",
                    Email = "maria.oliveira@example.com",
                    CellPhone = "21998765432",
                    Phone = "2134567890",
                    RegisterDate = DateTime.UtcNow
                }
            );
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Colchões",
                    Description = "Linha completa de colchões de solteiro, casal e queen/king size"
                },
                new Category
                {
                    Id = 2,
                    Name = "Travesseiros",
                    Description = "Travesseiros de espuma, látex, viscoelástico e anatômicos"
                },
                new Category
                {
                    Id = 3,
                    Name = "Roupa de Cama",
                    Description = "Lençóis, fronhas, edredons e protetores de colchão"
                },
                new Category
                {
                    Id = 4,
                    Name = "Móveis de Quarto",
                    Description = "Cabeceiras, mesas de cabeceira e guarda-roupas"
                }
            );
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Colchão Casal Ortobom",
                    Description = "Colchão de casal ortopédico com molas ensacadas",
                    CostPrice = 1200.00m,
                    Height = 25.0m,
                    Width = 138.0m,
                    MeasureType = "cm",
                    Stock = 15,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Colchão Queen Viscoelástico",
                    Description = "Colchão queen size com camada de viscoelástico para maior conforto",
                    CostPrice = 2200.00m,
                    Height = 30.0m,
                    Width = 158.0m,
                    MeasureType = "cm",
                    Stock = 10,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Travesseiro NASA",
                    Description = "Travesseiro viscoelástico com memória, tecnologia NASA",
                    CostPrice = 180.00m,
                    Height = 15.0m,
                    Width = 60.0m,
                    MeasureType = "cm",
                    Stock = 50,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Jogo de Lençol Casal 300 fios",
                    Description = "Lençol 300 fios algodão egípcio com fronhas inclusas",
                    CostPrice = 350.00m,
                    Height = 0.5m,
                    Width = 200.0m,
                    MeasureType = "cm",
                    Stock = 40,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 5,
                    Name = "Cabeceira Estofada Queen",
                    Description = "Cabeceira estofada para cama queen, acabamento em linho",
                    CostPrice = 900.00m,
                    Height = 120.0m,
                    Width = 160.0m,
                    MeasureType = "cm",
                    Stock = 8,
                    CategoryId = 4
                }
            );
        }
    }
}
