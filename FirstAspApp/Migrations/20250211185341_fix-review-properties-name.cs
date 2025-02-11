using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAspApp.Migrations
{
    /// <inheritdoc />
    public partial class fixreviewpropertiesname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_VideoGames_VideoGameId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "VideoGameId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_VideoGames_VideoGameId",
                table: "Reviews",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_VideoGames_VideoGameId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "VideoGameId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_VideoGames_VideoGameId",
                table: "Reviews",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id");
        }
    }
}
