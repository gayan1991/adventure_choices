using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adventure.Application.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(5940), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 0, 0, 0, 0))),
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 560, DateTimeKind.Unspecified).AddTicks(430), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 560, DateTimeKind.Unspecified).AddTicks(746), new TimeSpan(0, 0, 0, 0, 0))),
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(8497), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 0, 0, 0, 0))),
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 560, DateTimeKind.Unspecified).AddTicks(1623), new TimeSpan(0, 0, 0, 0, 0))),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "System"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 560, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 0, 0, 0, 0))),
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
                values: new object[] { new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4065), new TimeSpan(0, 0, 0, 0, 0)), "System", "Doughnut Selection", new DateTimeOffset(new DateTime(2022, 11, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4065), new TimeSpan(0, 0, 0, 0, 0)), "System" });

            migrationBuilder.InsertData(
                table: "AdventureSelection",
                columns: new[] { "Id", "Action", "AdventureId", "Code", "CreatedAt", "CreatedBy", "ParentCode", "Text", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("01b4406e-8142-4d77-acbc-388bb1bbc1dd"), "Yes", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)7, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4272), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)4, "What are you waiting for? Grab it now.", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4272), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("02217c64-168e-46fa-996a-0b6225485fb2"), "Yes", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)3, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4227), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)1, "Are you sure?", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4228), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("10dcb061-2385-407c-8f39-dcd7ca8920bf"), "Yes", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)1, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4212), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)0, "Do I deserve it?", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4212), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("35c84599-bdcf-4e0f-a18d-2103adaff2bb"), "No", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)4, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)1, "Is it a good doughnut?", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("46350bf6-1b21-43ea-b46c-e67caac4c70e"), "No", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)8, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4279), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)4, "Wait 'till you find a sinful unforgettable doughnut.", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4279), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("75205189-e254-4a13-b9a7-2468877b5532"), null, new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)0, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 0, 0, 0, 0)), "System", null, "DO I WANT A DOUGHNUT?", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4191), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("ac9d797b-6609-42b6-9943-4dc88fc91670"), "Yes", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)5, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4254), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)3, "Get it.", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4254), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("e86a9439-366c-4875-b49f-e3b63c3ad32a"), "No", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)6, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4264), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)3, "Do jumping jacks first.", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4265), new TimeSpan(0, 0, 0, 0, 0)), "System" },
                    { new Guid("fa1d2064-be94-4445-888d-20b1fd4b374e"), "No", new Guid("3afb0c39-647a-47c2-8852-e6f9a55c7985"), (byte)2, new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4220), new TimeSpan(0, 0, 0, 0, 0)), "System", (byte)0, "Maybe you want an apple?", new DateTimeOffset(new DateTime(2022, 10, 16, 0, 23, 0, 559, DateTimeKind.Unspecified).AddTicks(4221), new TimeSpan(0, 0, 0, 0, 0)), "System" }
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
