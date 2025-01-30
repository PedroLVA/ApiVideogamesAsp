using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAspApp.Migrations
{
    /// <inheritdoc />
    public partial class GenreVideogameRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreVideoGame",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    ListOfVideogamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreVideoGame", x => new { x.GenresId, x.ListOfVideogamesId });
                    table.ForeignKey(
                        name: "FK_GenreVideoGame_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreVideoGame_VideoGames_ListOfVideogamesId",
                        column: x => x.ListOfVideogamesId,
                        principalTable: "VideoGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreVideoGame_ListOfVideogamesId",
                table: "GenreVideoGame",
                column: "ListOfVideogamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreVideoGame");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
