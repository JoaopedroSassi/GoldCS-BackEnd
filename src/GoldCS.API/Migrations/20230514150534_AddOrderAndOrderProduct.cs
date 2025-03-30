using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class AddOrderAndOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymetMethod = table.Column<string>(type: "varchar(200)", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    DeliveryForecast = table.Column<DateTime>(type: "date", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: false),
                    AddressID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "tb_address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "tb_clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_users_UserID",
                        column: x => x.UserID,
                        principalTable: "tb_users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_order_product",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order_product", x => new { x.ProductID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_tb_order_product_tb_order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "tb_order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_order_product_tb_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tb_products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_AddressID",
                table: "tb_order",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_ClientID",
                table: "tb_order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_UserID",
                table: "tb_order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_product_OrderID",
                table: "tb_order_product",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_order_product");

            migrationBuilder.DropTable(
                name: "tb_order");
        }
    }
}
