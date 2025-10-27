using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCS.Infraestructure.Migrations.GoldResourcesDb
{
    /// <inheritdoc />
    public partial class InclusionDateColumProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InclusionDate",
                table: "Products",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2025, 10, 24, 2, 34, 57, 166, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2025, 10, 24, 2, 34, 57, 166, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 23, 23, 34, 57, 166, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 23, 23, 34, 57, 166, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 23, 23, 34, 57, 166, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 23, 23, 34, 57, 166, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 23, 23, 34, 57, 166, DateTimeKind.Local).AddTicks(1661));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InclusionDate",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2025, 10, 24, 1, 45, 36, 805, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2025, 10, 24, 1, 45, 36, 805, DateTimeKind.Utc).AddTicks(1432));
        }
    }
}
