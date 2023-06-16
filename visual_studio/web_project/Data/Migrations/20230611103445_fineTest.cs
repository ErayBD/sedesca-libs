using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class fineTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_authorId",
                table: "Books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_genreId",
                table: "Books",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_authorId",
                table: "Books",
                column: "authorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genre_genreId",
                table: "Books",
                column: "genreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_authorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genre_genreId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_authorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_genreId",
                table: "Books");
        }
    }
}
