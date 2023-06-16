using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class user2Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Students",
                newName: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Students",
                newName: "UserId");
        }
    }
}
