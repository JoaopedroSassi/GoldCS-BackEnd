using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoldCS.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class login_creation_user_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WebService");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "WebService",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "WebService");
        }
    }
}
