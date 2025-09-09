using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class RemoveDeleteOnBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount",
                column: "ProductID",
                principalTable: "tb_products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount",
                column: "ProductID",
                principalTable: "tb_products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
