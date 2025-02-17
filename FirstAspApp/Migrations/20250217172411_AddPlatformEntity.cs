using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAspApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatformEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformVideoGame",
                columns: table => new
                {
                    ListOfVideoGamesId = table.Column<int>(type: "int", nullable: false),
                    PlatformsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformVideoGame", x => new { x.ListOfVideoGamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_PlatformVideoGame_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformVideoGame_VideoGames_ListOfVideoGamesId",
                        column: x => x.ListOfVideoGamesId,
                        principalTable: "VideoGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformVideoGame_PlatformsId",
                table: "PlatformVideoGame",
                column: "PlatformsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformVideoGame");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
