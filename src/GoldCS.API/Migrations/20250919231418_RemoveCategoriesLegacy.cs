using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldCSAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategoriesLegacy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_products_tb_categories_CategoryID",
                table: "tb_products");

            migrationBuilder.DropTable(
                name: "tb_categories");

            migrationBuilder.DropIndex(
                name: "IX_tb_products_CategoryID",
                table: "tb_products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categories", x => x.CategoryID);
                });

            migrationBuilder.InsertData(
                table: "tb_categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Colchão" },
                    { 2, "Cama" },
                    { 3, "Travesseiro" },
                    { 4, "Outros" },
                    { 5, "Base / Baú" },
                    { 6, "Cabeceira" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_products_CategoryID",
                table: "tb_products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_products_tb_categories_CategoryID",
                table: "tb_products",
                column: "CategoryID",
                principalTable: "tb_categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
