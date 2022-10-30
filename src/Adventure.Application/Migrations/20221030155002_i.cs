using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adventure.Application.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdventureSelection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdventureSelection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdventureSelection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    ParentCode = table.Column<byte>(type: "tinyint", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AdventureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(6810), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureSelection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdventureSelection_Adventure_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdventureStepsSelection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Step = table.Column<byte>(type: "tinyint", nullable: false),
                    AdventureSelectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(9805), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdventureStepsSelection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdventureStepsSelection_UserAdventureSelection_AdventureSelectionId",
                        column: x => x.AdventureSelectionId,
                        principalTable: "UserAdventureSelection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adventure",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 0, 0, 0, 0)), "System", "Doughnut Selection", new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                table: "AdventureSelection",
                columns: new[] { "Id", "Action", "AdventureId", "Code", "ParentCode", "Text" },
                values: new object[,]
                {
                    { new Guid("0a7d4e14-7289-4602-bcb6-4962b9c84dba"), "Yes", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)7, (byte)4, "What are you waiting for? Grab it now." },
                    { new Guid("1c35f41f-1fbe-4269-90b3-e6c80ecf8435"), "No", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)6, (byte)3, "Do jumping jacks first." },
                    { new Guid("4340e385-bbbc-419b-ab08-da0bd2be7c2b"), "No", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)2, (byte)0, "Maybe you want an apple?" },
                    { new Guid("5297d938-0c1e-4cfd-b243-dfc1763ae463"), "Yes", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)5, (byte)3, "Get it." },
                    { new Guid("6420f1a5-fa31-4eee-8d5a-9a813699594c"), "No", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)4, (byte)1, "Is it a good doughnut?" },
                    { new Guid("a9f73734-121c-4ed4-9770-046134be1c96"), "Yes", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)1, (byte)0, "Do I deserve it?" },
                    { new Guid("d09f457e-6bfd-45e0-88c9-52088777bcaa"), "No", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)8, (byte)4, "Wait 'till you find a sinful unforgettable doughnut." },
                    { new Guid("fa351139-3ad6-4794-b71d-9e690692e6d2"), null, new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)0, null, "DO I WANT A DOUGHNUT?" },
                    { new Guid("fc7bb943-73f7-4400-99b0-eafa6fcfa8a9"), "Yes", new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"), (byte)3, (byte)1, "Are you sure?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventureSelection_AdventureId",
                table: "AdventureSelection",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventureStepsSelection_AdventureSelectionId",
                table: "UserAdventureStepsSelection",
                column: "AdventureSelectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventureSelection");

            migrationBuilder.DropTable(
                name: "UserAdventureStepsSelection");

            migrationBuilder.DropTable(
                name: "Adventure");

            migrationBuilder.DropTable(
                name: "UserAdventureSelection");
        }
    }
}
