using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class AddAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    AddressName = table.Column<string>(type: "varchar(200)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    District = table.Column<string>(type: "varchar(100)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    Number = table.Column<string>(type: "varchar(25)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "tb_amount",
                columns: table => new
                {
                    AmountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_amount", x => x.AmountID);
                    table.ForeignKey(
                        name: "FK_tb_amount_tb_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tb_products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_amount_ProductID",
                table: "tb_amount",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_address");

            migrationBuilder.DropTable(
                name: "tb_amount");
        }
    }
}
