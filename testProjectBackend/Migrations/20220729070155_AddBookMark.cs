using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testProjectBackend.Migrations
{
    public partial class AddBookMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1df1b1e2-fe73-4f7b-b22e-2478ac6b468f"));

            migrationBuilder.CreateTable(
                name: "BookMarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameRepository = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMarks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Token" },
                values: new object[] { new Guid("bd1438f1-2e8a-4dd8-afd1-eae91dc709c7"), "demo@gmail.com", "Test123!", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMarks");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd1438f1-2e8a-4dd8-afd1-eae91dc709c7"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Token" },
                values: new object[] { new Guid("1df1b1e2-fe73-4f7b-b22e-2478ac6b468f"), "demo@gmail.com", "Test123!", null });
        }
    }
}
