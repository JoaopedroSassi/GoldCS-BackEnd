using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class AlterOrderAndProductRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_order_product_tb_order_OrderID1",
                table: "tb_order_product");

            migrationBuilder.DropIndex(
                name: "IX_tb_order_product_OrderID1",
                table: "tb_order_product");

            migrationBuilder.DropColumn(
                name: "OrderID1",
                table: "tb_order_product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderID1",
                table: "tb_order_product",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_product_OrderID1",
                table: "tb_order_product",
                column: "OrderID1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_order_product_tb_order_OrderID1",
                table: "tb_order_product",
                column: "OrderID1",
                principalTable: "tb_order",
                principalColumn: "OrderID");
        }
    }
}
