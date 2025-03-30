using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class UpdatePaymeToPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymetMethod",
                table: "tb_order",
                newName: "PaymentMethod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "tb_order",
                newName: "PaymetMethod");
        }
    }
}
