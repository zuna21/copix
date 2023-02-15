using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingSomeRowsJournalists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Journalists");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Journalists");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Journalists");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Journalists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Journalists");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Journalists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Journalists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Journalists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Journalists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Journalists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Journalists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Journalists",
                type: "TEXT",
                nullable: true);
        }
    }
}
