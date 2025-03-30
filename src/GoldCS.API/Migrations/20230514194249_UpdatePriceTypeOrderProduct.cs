using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class UpdatePriceTypeOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "tb_order_product",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "tb_order_product",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
