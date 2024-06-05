using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreLana.Data.Migrations
{
    /// <inheritdoc />
    public partial class books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Authers_AutherId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategories_Book_BookId",
                table: "BooksCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AutherId",
                table: "Books",
                newName: "IX_Books_AutherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authers_AutherId",
                table: "Books",
                column: "AutherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategories_Books_BookId",
                table: "BooksCategories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authers_AutherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategories_Books_BookId",
                table: "BooksCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AutherId",
                table: "Book",
                newName: "IX_Book_AutherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Authers_AutherId",
                table: "Book",
                column: "AutherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategories_Book_BookId",
                table: "BooksCategories",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
