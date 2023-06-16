using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class mybooksadded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MyBooks_authorId",
                table: "MyBooks",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_MyBooks_genreId",
                table: "MyBooks",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyBooks_Author_authorId",
                table: "MyBooks",
                column: "authorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyBooks_Genre_genreId",
                table: "MyBooks",
                column: "genreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyBooks_Author_authorId",
                table: "MyBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_MyBooks_Genre_genreId",
                table: "MyBooks");

            migrationBuilder.DropIndex(
                name: "IX_MyBooks_authorId",
                table: "MyBooks");

            migrationBuilder.DropIndex(
                name: "IX_MyBooks_genreId",
                table: "MyBooks");
        }
    }
}
