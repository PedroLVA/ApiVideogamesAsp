using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAspApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangePlatformVideoGamesFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformVideoGame_VideoGames_ListOfVideoGamesId",
                table: "PlatformVideoGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformVideoGame",
                table: "PlatformVideoGame");

            migrationBuilder.DropIndex(
                name: "IX_PlatformVideoGame_PlatformsId",
                table: "PlatformVideoGame");

            migrationBuilder.RenameColumn(
                name: "ListOfVideoGamesId",
                table: "PlatformVideoGame",
                newName: "VideoGamesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformVideoGame",
                table: "PlatformVideoGame",
                columns: new[] { "PlatformsId", "VideoGamesId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformVideoGame_VideoGamesId",
                table: "PlatformVideoGame",
                column: "VideoGamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformVideoGame_VideoGames_VideoGamesId",
                table: "PlatformVideoGame",
                column: "VideoGamesId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformVideoGame_VideoGames_VideoGamesId",
                table: "PlatformVideoGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformVideoGame",
                table: "PlatformVideoGame");

            migrationBuilder.DropIndex(
                name: "IX_PlatformVideoGame_VideoGamesId",
                table: "PlatformVideoGame");

            migrationBuilder.RenameColumn(
                name: "VideoGamesId",
                table: "PlatformVideoGame",
                newName: "ListOfVideoGamesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformVideoGame",
                table: "PlatformVideoGame",
                columns: new[] { "ListOfVideoGamesId", "PlatformsId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformVideoGame_PlatformsId",
                table: "PlatformVideoGame",
                column: "PlatformsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformVideoGame_VideoGames_ListOfVideoGamesId",
                table: "PlatformVideoGame",
                column: "ListOfVideoGamesId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
