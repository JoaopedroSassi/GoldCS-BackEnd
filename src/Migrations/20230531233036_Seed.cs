using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldCSAPI.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Colchão" },
                    { 2, "Cama" },
                    { 3, "Travesseiro" },
                    { 4, "Outros" },
                    { 5, "Base / Baú" },
                    { 6, "Cabeceira" }
                });

            migrationBuilder.InsertData(
                table: "tb_users",
                columns: new[] { "UserID", "Active", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 3, true, "franchesco@gmail.com", "Franchesco legal", "$2a$12$vHinXxf4yXtBDfGY6rVpae0VrQ2UladDGL4VydcbrwUd.sj4yY3sy", "admin" },
                    { 4, true, "jones@gmail.com", "Jones legal", "$2a$12$vHinXxf4yXtBDfGY6rVpae0VrQ2UladDGL4VydcbrwUd.sj4yY3sy", "seller" }
                });

            migrationBuilder.InsertData(
                table: "tb_products",
                columns: new[] { "ProductID", "CategoryID", "Name", "Price", "Quantity", "Version" },
                values: new object[,]
                {
                    { 1, 5, "Baú casal Blidado", 890m, 10, "1.38 x 1.88" },
                    { 2, 6, "Cabeceira Queen", 390m, 100, "1.58" },
                    { 3, 1, "Colchão ProRelax Opala", 1500m, 10, "1.38 x 1.88 x 24cm" },
                    { 4, 3, "Travesseiro Nasa DualFlex", 150m, 20, "16cm" },
                    { 5, 3, "Travesseiro Cervical", 160m, 50, "-" },
                    { 6, 1, "Colchão SanKonfort Le Griff", 2400m, 200, "1.38 x 188 x 33cm" },
                    { 7, 1, "Colchão SanKonfort Le Griff", 2990m, 30, "1.58 x 198 x 33cm" },
                    { 8, 1, "Colchão SanKonfort Le Griff", 3200m, 90, "1.93 x 203 x 33cm " },
                    { 9, 2, "Cama Bedrom Andressa Avelã", 2300m, 60, "1.38 x 188" },
                    { 10, 1, "Colchão ProRelax Pro Hotel", 1500m, 70, "1.38 x 188 x 28cm" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tb_products",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tb_users",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_users",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_categories",
                keyColumn: "CategoryID",
                keyValue: 6);
        }
    }
}
