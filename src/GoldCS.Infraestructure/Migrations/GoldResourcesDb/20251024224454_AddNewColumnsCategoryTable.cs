using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCS.Infraestructure.Migrations.GoldResourcesDb
{
    /// <inheritdoc />
    public partial class AddNewColumnsCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InclusionDate",
                table: "Categories",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "InclusionDate" },
                values: new object[] { true, new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "InclusionDate" },
                values: new object[] { true, new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "InclusionDate" },
                values: new object[] { true, new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "InclusionDate" },
                values: new object[] { true, new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2025, 10, 24, 22, 44, 53, 651, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2025, 10, 24, 22, 44, 53, 651, DateTimeKind.Utc).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "InclusionDate",
                value: new DateTime(2025, 10, 24, 19, 44, 53, 651, DateTimeKind.Local).AddTicks(4808));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "InclusionDate",
                table: "Categories");

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
    }
}
