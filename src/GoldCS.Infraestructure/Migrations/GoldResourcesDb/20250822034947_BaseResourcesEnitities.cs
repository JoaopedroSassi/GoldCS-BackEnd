using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldCS.Infraestructure.Migrations.GoldResourcesDb
{
    /// <inheritdoc />
    public partial class BaseResourcesEnitities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 150, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(100)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "varchar(100)", maxLength: 15, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Height = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Width = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    MeasureType = table.Column<string>(type: "varchar(100)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    AdressType = table.Column<int>(type: "integer", nullable: false),
                    CEP = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    UF = table.Column<string>(type: "varchar(100)", maxLength: 2, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AdressId = table.Column<int>(type: "integer", nullable: true),
                    Subtotal = table.Column<decimal>(type: "numeric(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    UnitaryValue = table.Column<double>(type: "numeric(12,2)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalValue = table.Column<decimal>(type: "numeric(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Linha completa de colchões de solteiro, casal e queen/king size", "Colchões" },
                    { 2, "Travesseiros de espuma, látex, viscoelástico e anatômicos", "Travesseiros" },
                    { 3, "Lençóis, fronhas, edredons e protetores de colchão", "Roupa de Cama" },
                    { 4, "Cabeceiras, mesas de cabeceira e guarda-roupas", "Móveis de Quarto" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CellPhone", "Cpf", "Email", "Name", "Phone", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "11912345678", "12345678901", "joao.silva@example.com", "João Silva", "1132345678", new DateTime(2025, 8, 22, 3, 49, 47, 590, DateTimeKind.Utc).AddTicks(8084) },
                    { 2, "21998765432", "98765432100", "maria.oliveira@example.com", "Maria Oliveira", "2134567890", new DateTime(2025, 8, 22, 3, 49, 47, 590, DateTimeKind.Utc).AddTicks(8086) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CostPrice", "Description", "Height", "MeasureType", "Name", "Stock", "Width" },
                values: new object[,]
                {
                    { 1, 1, 1200.00m, "Colchão de casal ortopédico com molas ensacadas", 25.0m, "cm", "Colchão Casal Ortobom", 15, 138.0m },
                    { 2, 1, 2200.00m, "Colchão queen size com camada de viscoelástico para maior conforto", 30.0m, "cm", "Colchão Queen Viscoelástico", 10, 158.0m },
                    { 3, 2, 180.00m, "Travesseiro viscoelástico com memória, tecnologia NASA", 15.0m, "cm", "Travesseiro NASA", 50, 60.0m },
                    { 4, 3, 350.00m, "Lençol 300 fios algodão egípcio com fronhas inclusas", 0.5m, "cm", "Jogo de Lençol Casal 300 fios", 40, 200.0m },
                    { 5, 4, 900.00m, "Cabeceira estofada para cama queen, acabamento em linho", 120.0m, "cm", "Cabeceira Estofada Queen", 8, 160.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdressId",
                table: "Orders",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
