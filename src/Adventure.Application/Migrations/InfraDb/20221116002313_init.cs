using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adventure.Application.Migrations.InfraDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.CreateTable(
                name: "Audit",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Table = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestResponseLog",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteValues = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestResponseLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RequestResponseLog",
                schema: "system");
        }
    }
}
