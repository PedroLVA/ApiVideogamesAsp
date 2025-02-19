using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstAspApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlatformFieldFromVideoGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "VideoGames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "VideoGames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "DeveloperId", "Platform", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, null, null, null, "The Legend of Zelda: Breath of the Wild" },
                    { 2, null, "PlayStation 4", null, "God of War" },
                    { 3, null, "PC, PlayStation, Xbox", null, "Cyberpunk 2077" },
                    { 4, null, "Xbox, PC", null, "Halo Infinite" },
                    { 5, null, "PlayStation, Xbox, PC", null, "Red Dead Redemption 2" }
                });
        }
    }
}
