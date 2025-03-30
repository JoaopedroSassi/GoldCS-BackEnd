using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class UpdateTypeDoubleToDecimalAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "tb_amount",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount",
                column: "ProductID",
                principalTable: "tb_products",
                principalColumn: "ProductID"
			);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "tb_amount",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_amount_tb_products_ProductID",
                table: "tb_amount",
                column: "ProductID",
                principalTable: "tb_products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
