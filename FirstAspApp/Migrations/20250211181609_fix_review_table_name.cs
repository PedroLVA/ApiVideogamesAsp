using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAspApp.Migrations
{
    /// <inheritdoc />
    public partial class fix_review_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_Users_UserId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_VideoGames_VideoGameId",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reviews",
                table: "reviews");

            migrationBuilder.RenameTable(
                name: "reviews",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_VideoGameId",
                table: "Reviews",
                newName: "IX_Reviews_VideoGameId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_VideoGames_VideoGameId",
                table: "Reviews",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_VideoGames_VideoGameId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_VideoGameId",
                table: "reviews",
                newName: "IX_reviews_VideoGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "reviews",
                newName: "IX_reviews_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reviews",
                table: "reviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_Users_UserId",
                table: "reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_VideoGames_VideoGameId",
                table: "reviews",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id");
        }
    }
}
