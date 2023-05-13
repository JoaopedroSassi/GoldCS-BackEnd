using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class UpdateTypeDateTimeAomunt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AmountDate",
                table: "tb_amount",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AmountDate",
                table: "tb_amount",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
