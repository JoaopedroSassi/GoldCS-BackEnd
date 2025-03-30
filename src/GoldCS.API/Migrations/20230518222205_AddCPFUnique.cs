using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class AddCPFUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_clients_Cpf",
                table: "tb_clients",
                column: "Cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_clients_Cpf",
                table: "tb_clients");
        }
    }
}
