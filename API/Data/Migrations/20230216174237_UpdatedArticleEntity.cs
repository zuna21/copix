using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedArticleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Articles_JournalistId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "JournalistId",
                table: "Article",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Articles_JournalistId",
                table: "Article",
                column: "JournalistId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Articles_JournalistId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "JournalistId",
                table: "Article",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Articles_JournalistId",
                table: "Article",
                column: "JournalistId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
