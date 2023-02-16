using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedJournalistEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Journalists",
                table: "Journalists");

            migrationBuilder.RenameTable(
                name: "Journalists",
                newName: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Articles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Articles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Articles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    JournalistId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Articles_JournalistId",
                        column: x => x.JournalistId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_JournalistId",
                table: "Article",
                column: "JournalistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Journalists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journalists",
                table: "Journalists",
                column: "Id");
        }
    }
}
